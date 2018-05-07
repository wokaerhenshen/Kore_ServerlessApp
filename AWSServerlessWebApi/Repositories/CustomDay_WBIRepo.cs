using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Repositories
{
    public class CustomDay_WBIRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public CustomDay_WBIRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public CustomDay_WBI CreateTimeslipTemplate(CustomDay_WBIVM customDay_WBIVM)
        {
            Guid wbiGuid = Guid.Parse(customDay_WBIVM.WBI_Id);
            // application user needs to be here
            CustomDay_WBI timeslip_template = new CustomDay_WBI()
            {
                NewChangeRequestId = wbiGuid,
                CustomDayId = customDay_WBIVM.CustomDayId,
                Remarks = customDay_WBIVM.Remarks
            };

            if (customDay_WBIVM.StartTime != null)
            {
                timeslip_template.StartTime = DateTime.Parse(customDay_WBIVM.StartTime);
            }
            else
            {
                throw new ArgumentNullException("You need to enter a start time...");
            }
            if (customDay_WBIVM.EndTime != null)
            {
                timeslip_template.EndTime = DateTime.Parse(customDay_WBIVM.EndTime);
            }
            else
            {
                throw new ArgumentNullException("You need to enter an end time...");
            }

            foreach (var item in _context.Timeslip_Templates.Where(i=> i.CustomDayId == customDay_WBIVM.CustomDayId))
            {
                

                    if (item.StartTime > timeslip_template.EndTime || item.EndTime < timeslip_template.StartTime)
                    {
                        //throw new ArgumentException("Times cannot overlap");
                    }
                    else
                    {

                    throw new ArgumentException("Times cannot overlap");

                    }
            }
            _context.Timeslip_Templates.Add(timeslip_template);
            _context.SaveChanges();

            return timeslip_template;
        }

        public List<CustomDay_WBI> GetAllTimeslipTemplateByCustomDay(string customDayId)
        {
            return _context.Timeslip_Templates.Where(t => t.CustomDayId == customDayId).ToList();
        }

        public CustomDay_WBI GetOneTimeslipTemplate(string id)
        {
            return _context.Timeslip_Templates.Where(t => t.TimeslipTemplateId == id).FirstOrDefault();
        }

        public List<CustomDay_WBIWithWBINameVM> GetAllTimeslipTemplatesByCustomDayWithWBIName(string customDayId)
        {
            WBIRepo wbiRepo = new WBIRepo(_context);

            var timeslipTemplateListByCustomDay = GetAllTimeslipTemplateByCustomDay(customDayId);

            var timeslipTemplateListWithWBIName = new List<CustomDay_WBIWithWBINameVM>();

            foreach (CustomDay_WBI t in timeslipTemplateListByCustomDay)
            {
                CustomDay_WBIWithWBINameVM customDay_WBIWithWBINameVM = new CustomDay_WBIWithWBINameVM()
                {
                    TimeslipTemplateId = t.TimeslipTemplateId,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    Remarks = t.Remarks,
                    NewChangeRequestId = t.NewChangeRequestId,
                    WBIName = _context.NewChangeRequestExtensionBase.Where(u => u.NewChangeRequestId == t.NewChangeRequestId).FirstOrDefault().NewName
                };

                timeslipTemplateListWithWBIName.Add(customDay_WBIWithWBINameVM);
            }

            return timeslipTemplateListWithWBIName;
        }

        public bool EditTimeslipTemplate(CustomDay_WBIVM customDay_WBIVM)
        {

            var timeslip_template = GetOneTimeslipTemplate(customDay_WBIVM.TimeslipTemplateId);
            if (timeslip_template == null)
            {
                return false;
            }
            else
            {
                timeslip_template.StartTime = DateTime.Parse(customDay_WBIVM.StartTime);
                timeslip_template.EndTime = DateTime.Parse(customDay_WBIVM.EndTime);
                timeslip_template.Remarks = customDay_WBIVM.Remarks;

                _context.SaveChanges();

                return true;
            }
        }

        public bool DeleteOneTimeslipTemplate(string id)
        {
            var timeslip_template = GetOneTimeslipTemplate(id);

            if (timeslip_template == null)
            {
                return false;
            }

            _context.Timeslip_Templates.Remove(timeslip_template);
            _context.SaveChanges();

            return true;
        }
    }
}
