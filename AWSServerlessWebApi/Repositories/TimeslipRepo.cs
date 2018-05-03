using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace AWSServerlessWebApi.Repositories
{
    public class TimeslipRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public TimeslipRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public NewTimesheetEntryExtensionBase CreateTimeslip (TimeslipVM timeslipVM)
        {
            Guid userGuid = Guid.Parse(timeslipVM.UserId);
            Guid wbiGuid = Guid.Parse(timeslipVM.WBI_Id);
            // application user needs to be here
            NewTimesheetEntryExtensionBase timeslip = new NewTimesheetEntryExtensionBase()
            {
                NewTimesheetEntryId = Guid.NewGuid(),
                NewRemarks = timeslipVM.Remarks,
                CustomDayId = timeslipVM.DayId,
                NewChangeRequestId = wbiGuid,
                OwningUser = userGuid,
                NewStartTask = DateTime.Parse(timeslipVM.StartTime),
                NewEndTask = DateTime.Parse(timeslipVM.EndTime)
        };

            TimeSpan? duration = timeslip.NewEndTask - timeslip.NewStartTask;

            int durationInHours = (int)duration?.TotalHours;

            NewChangeRequestExtensionBase wbi = _context.NewChangeRequestExtensionBase
                                                .Where(w => w.NewChangeRequestId == timeslip.NewChangeRequestId)
                                                .FirstOrDefault();

            wbi.NewActualHours += durationInHours;

            if (wbi.NewActualHours > wbi.NewEstimatedHours)
            {
                throw new ArgumentException("Alloted hours for this WBI has been maxed out.");
            }
            // a.start <= b.end && a.end >= b.start 

            var date = Convert.ToDateTime(timeslip.NewStartTask);
            var sameDate = date.Date;

            foreach (var item in _context.NewTimesheetEntryExtensionBase
                                         .Where(u => Convert.ToDateTime(u.NewStartTask).Date == sameDate && 
                                                     u.OwningUser == userGuid))
            {
                if (item.NewTimesheetEntryId != timeslip.NewTimesheetEntryId)
                {
                    if (item.NewStartTask <= timeslip.NewEndTask && item.NewEndTask >= timeslip.NewStartTask)
                    {
                        throw new ArgumentException("Times cannot overlap");
                    }
                }
            }
            _context.NewTimesheetEntryExtensionBase.Add(timeslip);
            _context.SaveChanges();

            return timeslip;
        }

        public bool CreateTimeslipsByCustomDay(CustomDateVM customDateVM)
        {
            CustomDay_WBIRepo customDay_WBIRepo = new CustomDay_WBIRepo(_context);
            CustomDayRepo customDayRepo = new CustomDayRepo(_context);

            var timeslipTemplateList = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(customDateVM.CustomdayId);
            CustomDay customDay = customDayRepo.GetOneCustomDay(customDateVM.CustomdayId);

            foreach (CustomDay_WBI tt in timeslipTemplateList)
            {
                DateTime newStartTime = new DateTime(DateTime.Parse(customDateVM.Date).Year, DateTime.Parse(customDateVM.Date).Month, DateTime.Parse(customDateVM.Date).Day, tt.StartTime.Hour, tt.StartTime.Minute, tt.StartTime.Second);
                DateTime newEndTime = new DateTime(DateTime.Parse(customDateVM.Date).Year, DateTime.Parse(customDateVM.Date).Month, DateTime.Parse(customDateVM.Date).Day, tt.EndTime.Hour, tt.EndTime.Minute, tt.EndTime.Second);

                TimeslipVM newTimeslip = new TimeslipVM()
                {
                    TimeslipId = null,
                    StartTime = Convert.ToString(newStartTime),
                    EndTime = Convert.ToString(newEndTime),
                    Remarks = tt.Remarks,
                    DayId = customDateVM.CustomdayId,
                    WBI_Id = Convert.ToString(tt.NewChangeRequestId),
                    UserId = Convert.ToString(customDay.UserId)
                };
                CreateTimeslip(newTimeslip);
            }
            return true;
        }
        public List<NewTimesheetEntryExtensionBase> GetAllTimeslips()
        {
            return _context.NewTimesheetEntryExtensionBase.ToList();
        }

        public NewTimesheetEntryExtensionBase GetOneTimeslip(string id)
        {
            Guid guid = Guid.Parse(id);
            return _context.NewTimesheetEntryExtensionBase.Where(t => t.NewTimesheetEntryId == guid).FirstOrDefault();
        }

        public List<NewTimesheetEntryExtensionBase> GetAllTimeslipsByUserId (Guid userId)
        {
            return _context.NewTimesheetEntryExtensionBase.Where(t => t.OwningUser == userId).ToList();
        }
        public List<NewTimesheetEntryExtensionBase> GetAllTimeslipsByUserIdWithDate(Guid userId, DateTime date)
        {
            return _context.NewTimesheetEntryExtensionBase.Where(t => t.OwningUser == userId && t.NewStartTask.Value.Date == date.Date).ToList();
        }
        public List<NewTimesheetEntryExtensionBase> GetAllTimeslipsByCustomDayId(string dayId)
        {
            return _context.NewTimesheetEntryExtensionBase.Where(t => t.CustomDayId == dayId).ToList();
        }

        public NewTimesheetEntryExtensionBase EditTimeslip(TimeslipVM timeslipVM)
        {
            
            var timeslip = GetOneTimeslip(timeslipVM.TimeslipId);
            if (timeslip == null)
            {
                return timeslip;
            }
            else
            {
                NewChangeRequestExtensionBase wbi = _context.NewChangeRequestExtensionBase
                                                    .Where(w => w.NewChangeRequestId == timeslip.NewChangeRequestId)
                                                    .FirstOrDefault();
                TimeSpan? oldDuration = timeslip.NewEndTask - timeslip.NewStartTask; //old timeslip's difference
                int oldDurationInHours = (int)oldDuration?.TotalHours;

                TimeSpan? newDuration = DateTime.Parse(timeslipVM.EndTime) - DateTime.Parse(timeslipVM.StartTime);//new timeslip's difference
                int newDurationInHours = (int)newDuration?.TotalHours;

                if (newDurationInHours > oldDurationInHours)
                {
                    //add 
                    int difference = newDurationInHours - oldDurationInHours;
                    wbi.NewActualHours = wbi.NewActualHours + difference;

                } else if (newDurationInHours < oldDurationInHours)
                {
                    //minus
                    int difference = oldDurationInHours - newDurationInHours;
                    wbi.NewActualHours = wbi.NewActualHours - difference;
                }

                timeslip.NewStartTask = DateTime.Parse(timeslipVM.StartTime);
                timeslip.NewEndTask = DateTime.Parse(timeslipVM.EndTime);
                timeslip.NewRemarks = timeslipVM.Remarks;
                
                _context.SaveChanges();
            }
            return timeslip;
        }

        public bool DeleteOneTimeslip(string id)
        {
            var timeslip = GetOneTimeslip(id);

            if (timeslip == null)
            {
                return false;
            }

            TimeSpan? duration = timeslip.NewEndTask - timeslip.NewStartTask;

            int durationInHours = (int)duration?.TotalHours;

            NewChangeRequestExtensionBase wbi = _context.NewChangeRequestExtensionBase
                                                .Where(w => w.NewChangeRequestId == timeslip.NewChangeRequestId)
                                                .FirstOrDefault();

            wbi.NewActualHours -= durationInHours;

            _context.NewTimesheetEntryExtensionBase.Remove(timeslip);
            _context.SaveChanges();
            return true;
        }

    }
}
