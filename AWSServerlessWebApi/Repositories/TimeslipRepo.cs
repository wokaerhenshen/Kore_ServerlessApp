using core_backend.Data;
using core_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class TimeslipRepo
    {
        ApplicationDbContext _context;

        public TimeslipRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Timeslip CreateTimeslip (string StartTime, string EndTime, string remarks, string tag, int workBreakDownId)
        {
            // application user needs to be here
            Timeslip timeslip = new Timeslip()
            {
                StartTime = DateTime.Parse(StartTime),
                EndTime = DateTime.Parse(EndTime),
                Remarks = remarks,
                Tag = tag,
                UserId = "1",
                WorkBreakdownItemId = workBreakDownId
            };
            _context.Timeslips.Add(timeslip);
            _context.SaveChanges();

            return timeslip;
        }

        public List<Timeslip> GetAllTimeslips()
        {
            return _context.Timeslips.ToList();
        }

        public Timeslip GetOneTimeslip(int id)
        {
            return _context.Timeslips.Where(t => t.TimeslipId == id).FirstOrDefault();
        }

        public Timeslip EditTimeslip(int id, string StartTime, string EndTime, string remarks, string tag)
        {
            var timeslip = GetOneTimeslip(id);
            if (timeslip == null)
            {
                return timeslip;
            }
            else
            {
                timeslip.StartTime = DateTime.Parse(StartTime);
                timeslip.EndTime = DateTime.Parse(EndTime);
                timeslip.Remarks = remarks;
                timeslip.Tag = tag;
                _context.SaveChanges();
            }
            return timeslip;
        }

        public Timeslip DeleteOneTimeslip(int id)
        {
            var timeslip = GetOneTimeslip(id);
            if (timeslip == null)
            {
                return timeslip;
            }
            _context.Timeslips.Remove(timeslip);
            _context.SaveChanges();
            return timeslip;
        }

    }
}
