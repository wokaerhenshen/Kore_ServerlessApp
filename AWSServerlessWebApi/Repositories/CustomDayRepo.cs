using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//FIX LATER
namespace AWSServerlessWebApi.Repositories
{
    public class CustomDayRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public CustomDayRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public bool CreateNewCustomDay(string Name, string Description)
        {
            CustomDay customDay = new CustomDay()
            {
                //fix later.
                CustomDayId = GenerateCustomDayId(),
                Name = Name,
                Description = Description
            };
            _context.CustomDays.Add(customDay);
            _context.SaveChanges();
            return true;
        }

        public List<CustomDay> GetAllCustomDays()
        {
            return _context.CustomDays.ToList();
        }

        public CustomDay GetOneCustomDay(string id)
        {
            return _context.CustomDays.Where(i => i.CustomDayId == id).FirstOrDefault();
        }

        public bool UpdateCustomDay(string id, string Name, string Description)
        {
            CustomDay customDay = _context.CustomDays.Where(i => i.CustomDayId == id).FirstOrDefault();
            customDay.Name = Name;
            customDay.Description = Description;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCustomDay(string id)
        {
            CustomDay customDay = _context.CustomDays.Where(i => i.CustomDayId == id).FirstOrDefault();
            _context.CustomDays.Remove(customDay);
            _context.SaveChanges();
            return true;
        }

        //public bool AssignTimeSlip(int customDayId, Guid timeslipId)
        //{
        //    CustomDayTimeSlip customDayTimeSlip = new CustomDayTimeSlip()
        //    {
        //        CustomDayId = customDayId,
        //        TimeSlipId = timeslipId
        //    };
        //    _context.CustomDayTimeSlips.Add(customDayTimeSlip);
        //    _context.SaveChanges();
        //    return true;
        //}

        //public bool DeleteTimeSlipInCustomDay(int customDayId, Guid timeslipId)
        //{
        //    CustomDayTimeSlip customDayTimeSlip = _context.CustomDayTimeSlips.Where(i => i.CustomDayId == customDayId && i.TimeSlipId == timeslipId).FirstOrDefault();
        //    _context.CustomDayTimeSlips.Remove(customDayTimeSlip);
        //    _context.SaveChanges();
        //    return true;
        //}

            //fix later.
        public string GenerateCustomDayId()
        {
            return _context.CustomDays.Select(i => i.CustomDayId) + "s";
        }
    }
}
