using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public string GenerateCustomDayId()
        {
            return RandomString(10);
        }
    }
}
