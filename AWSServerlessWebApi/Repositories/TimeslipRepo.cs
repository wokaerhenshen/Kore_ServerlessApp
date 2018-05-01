using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                OwningUser = userGuid
                
            };

            if(timeslipVM.StartTime != null)
            {
                //should use TryParse for safety...
                timeslip.NewStartTask = DateTime.Parse(timeslipVM.StartTime);
            }
            else
            {
                throw new ArgumentNullException("You need to enter a start time...");
            }
            if (timeslipVM.EndTime != null)
            {
                timeslip.NewEndTask = DateTime.Parse(timeslipVM.EndTime);
            }
            else
            {
                throw new ArgumentNullException("You need to enter an end time...");
            }

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
            foreach (var item in _context.NewTimesheetEntryExtensionBase)
            {
                if (item.NewTimesheetEntryId != timeslip.NewTimesheetEntryId)
                {
                    //if (timeslip.NewStartTask <= item.NewEndTask || item.NewStartTask >= timeslip.NewEndTask)
                    //{
                    //    throw new ArgumentException("Times cannot overlap");
                    //}
                    if ((item.NewStartTask <= timeslip.NewEndTask && item.NewEndTask >= timeslip.NewStartTask)
                        && (timeslip.NewStartTask >= item.NewStartTask && timeslip.NewEndTask <= item.NewEndTask))
                    {
                        throw new ArgumentException("Times cannot overlap");
                    }
                }
            }
            _context.NewTimesheetEntryExtensionBase.Add(timeslip);
            _context.SaveChanges();

            return timeslip;
        }
        //update this one
        //public bool CreateByCustomday(CustomDateVM customDateVM)
        //{
        //    List<NewTimesheetEntryExtensionBase> newTimesheetEntryExtensionBases= _context.NewTimesheetEntryExtensionBase.Where(i => i.CustomDayId == customDateVM.CustomdayId).ToList();
        //    foreach(var timeslip in newTimesheetEntryExtensionBases)
        //    {
        //        timeslip.NewStartTask = new DateTime(DateTime.Parse(customDateVM.Date).Year, DateTime.Parse(customDateVM.Date).Month,DateTime.Parse(customDateVM.Date).Day,timeslip.NewStartTask.Value.Hour,timeslip.NewStartTask.Value.Minute, timeslip.NewStartTask.Value.Second);
        //        timeslip.NewEndTask = new DateTime(DateTime.Parse(customDateVM.Date).Year, DateTime.Parse(customDateVM.Date).Month, DateTime.Parse(customDateVM.Date).Day, timeslip.NewEndTask.Value.Hour, timeslip.NewEndTask.Value.Minute, timeslip.NewEndTask.Value.Second);
        //        timeslip.NewTimesheetEntryId = Guid.NewGuid();
        //        timeslip.CustomDayId = "";
        //        _context.NewTimesheetEntryExtensionBase.Add(timeslip);
        //        _context.SaveChanges();
        //    };

        //    return true;
        //}

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

            _context.NewTimesheetEntryExtensionBase.Remove(timeslip);
            _context.SaveChanges();
            return true;
        }

    }
}
