
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class WBIRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public WBIRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public bool CreateWBI(WBIVM wbiVM)
        {
            NewChangeRequestExtensionBase wbi = new NewChangeRequestExtensionBase()
            {
                
                NewRemarks = wbiVM.Description,
                NewEstimatedHours = wbiVM.EstimatedHours,
                NewActualHours = wbiVM.ActualHours,
                NewProjectId = wbiVM.ProjectId
            };
            _context.NewChangeRequestExtensionBase.Add(wbi);
            _context.SaveChanges();

            return true;
        }

        public List<NewChangeRequestExtensionBase> GetAllWBIs()
        {
            return _context.NewChangeRequestExtensionBase.ToList();
        }

        public WorkBreakdownItem GetOneWBI(int id)
        {
            return _context.WorkBreakdownItems.Where(i => i.WorkBreakdownItemId == id)
                .FirstOrDefault();
        }
        public WorkBreakdownItem EditWBI(int id, string description, int estimatedHours, int actualHours)
        {
            var wbi = GetOneWBI(id);
            if (wbi == null)
            {
                return wbi;
            }
            else
            {
                
                wbi.Description = description;
                wbi.EstimatedHours = estimatedHours;
                wbi.ActualHours = actualHours;
               
                _context.SaveChanges();
            }
            return wbi;
        }
        public WorkBreakdownItem DeleteOneWBI(int id)
        {
            var wbi = GetOneWBI(id);
            if (wbi == null)
            {
                return wbi;
            }
            _context.WorkBreakdownItems.Remove(wbi);
            _context.SaveChanges();
            return wbi;
        }

    }
}
