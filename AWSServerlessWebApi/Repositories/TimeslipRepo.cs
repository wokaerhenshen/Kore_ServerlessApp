﻿using AWSServerlessWebApi.Models;
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
                NewStartTask = timeslipVM.StartTime,
                NewEndTask = timeslipVM.EndTime,
                NewRemarks = timeslipVM.Remarks,
                CustomDayId = timeslipVM.DayId,
                NewChangeRequestId = wbiGuid,
                OwningUser = userGuid
                
            };
            _context.NewTimesheetEntryExtensionBase.Add(timeslip);
            _context.SaveChanges();

            return timeslip;
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

        public NewTimesheetEntryExtensionBase EditTimeslip(TimeslipVM timeslipVM)
        {
            
            var timeslip = GetOneTimeslip(timeslipVM.TimeslipId);
            if (timeslip == null)
            {
                return timeslip;
            }
            else
            {
                timeslip.NewStartTask = timeslipVM.StartTime;
                timeslip.NewEndTask = timeslipVM.EndTime;
                timeslip.NewRemarks = timeslipVM.Remarks;
                
                _context.SaveChanges();
            }
            return timeslip;
        }

        public bool DeleteOneTimeslip(string id)
        {
            Guid timeslipGuid = Guid.Parse(id);
            //get all customday timeslips where TimeslipId == id
            //var customDayTimeslips = _context.CustomDayTimeSlips.Where(cd => cd.TimeSlipId == timeslipGuid).ToList();

            //foreach(var item in customDayTimeslips)
            //{
            //    _context.CustomDayTimeSlips.Remove(item);
            //    _context.SaveChanges();
            //}
            
            //Guid guid = Guid.Parse(id);
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
