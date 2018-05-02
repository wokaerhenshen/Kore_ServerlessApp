using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
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
        private static Random random = new Random();

        public CustomDayRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public CustomDay CreateCustomDay(CustomDayVM customDay)
        {
            CustomDay newCustomDay = new CustomDay()
            {
                CustomDayId = GenerateCustomDayId(),
                Name = customDay.Name,
                Description = customDay.Description,
                UserId = Guid.Parse(customDay.UserId)
                
            };
            
            _context.CustomDays.Add(newCustomDay);
            _context.SaveChanges();

            return newCustomDay;
        }

        //public bool CreateCustomDayWithTimeslipTemplate(CustomDayVM customDayVM)
        //{
        //    //create custom day
        //    string dayId = CreateCustomDay(customDayVM);
        //    //set the ID?

        //    //create timeslips
        //    if (customDayVM.TimeSlip != null)
        //    {
        //        foreach (TimeslipVM ts in customDayVM.TimeSlip)
        //        {
        //            ts.DayId = dayId;

        //            TimeslipRepo timeslipRepo = new TimeslipRepo(_context);
        //            timeslipRepo.CreateTimeslip(ts);
        //        }
                
        //    }
        //    return true;
        //}

        public List<CustomDay> GetAllCustomDays()
        {
            return _context.CustomDays.ToList();
        }

        public List<CustomDay> GetOneUserCustomDays(string id)
        {
            return _context.CustomDays.Where(i => i.UserId == Guid.Parse(id) && i.CustomDayId != "").ToList();
        }

        public CustomDay GetOneCustomDay(string id)
        {
            return _context.CustomDays.Where(i => i.CustomDayId == id).FirstOrDefault();
        }


        public bool UpdateCustomDay(CustomDayVM customDayVM)
        {
            CustomDay customDay = _context.CustomDays.Where(i => i.CustomDayId == customDayVM.CustomDayId).FirstOrDefault();
            customDay.Name = customDayVM.Name;
            customDay.Description = customDayVM.Description;
            _context.SaveChanges();
            return true;
        }

        //public bool DeleteCustomDay(string id)
        //{
        //    //remove references to CustomDay from relevant timeslips
        //    TimeslipRepo timeslipRepo = new TimeslipRepo(_context);

        //    var timeslips = timeslipRepo.GetAllTimeslipsByCustomDayId(id);

        //    foreach(NewTimesheetEntryExtensionBase timeslip in timeslips)
        //    {

        //        TimeslipVM timeslipVM = new TimeslipVM()
        //        {
        //            TimeslipId = Convert.ToString(timeslip.NewTimesheetEntryId),
        //            //the important part here is to remove the reference to the DayId
        //            DayId = null,
        //            StartTime = Convert.ToString(timeslip.NewStartTask),
        //            EndTime = Convert.ToString(timeslip.NewEndTask),
        //            Remarks = timeslip.NewRemarks,
        //            UserId = Convert.ToString(timeslip.OwningUser),
        //            WBI_Id = Convert.ToString(timeslip.NewChangeRequestId)
        //        };
        //        timeslipRepo.EditTimeslip( timeslipVM);
        //    }
        //    CustomDay customDay = GetOneCustomDay(id);
        //    _context.CustomDays.Remove(customDay);
        //    _context.SaveChanges();
        //    return true;
        //}
        public bool DeleteCustomDay(string id)
        {
            //delete all the templates first inside the custom day
            CustomDay_WBIRepo customDay_WBIRepo = new CustomDay_WBIRepo(_context);

            var timeslip_templates = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(id);

            foreach (CustomDay_WBI template in timeslip_templates)
            {
                customDay_WBIRepo.DeleteOneTimeslipTemplate(template.TimeslipTemplateId);
            }

            CustomDay customDay = GetOneCustomDay(id);
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


        public string GenerateCustomDayId()
        {
            return RandomString(10);
        }
    }
}
