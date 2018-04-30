
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Repositories
{
    public class WBIRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public WBIRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public NewChangeRequestExtensionBase CreateWBI( WBIVM wbiVM)
        {
            Guid projectGuid = Guid.Parse(wbiVM.ProjectId);
            NewChangeRequestExtensionBase wbi = new NewChangeRequestExtensionBase()
            {
                NewChangeRequestId = Guid.NewGuid(),
                NewRemarks = wbiVM.Description,
                NewEstimatedHours = wbiVM.EstimatedHours,
                NewActualHours = wbiVM.ActualHours,
                NewProjectId = projectGuid
            };
            _context.NewChangeRequestExtensionBase.Add(wbi);
            _context.SaveChanges();

            return wbi;
        }

        public List<NewChangeRequestExtensionBase> GetAllWBIs()
        {
            return _context.NewChangeRequestExtensionBase.ToList();
        }

        public List<NewChangeRequestExtensionBase> GetAllWBIsByProjectId(Guid id)
        {
            return _context.NewChangeRequestExtensionBase.Where(wbi => wbi.NewProjectId == id).ToList();
        }

        public NewChangeRequestExtensionBase GetOneWBI(Guid id)
        {
            return _context.NewChangeRequestExtensionBase.Where(i => i.NewChangeRequestId == id)
                .FirstOrDefault();
        }

        public NewChangeRequestExtensionBase EditWBI(WBIVM wbiVM)
        {
            Guid wbiGuid = Guid.Parse(wbiVM.WBI_Id);
            var wbi = GetOneWBI(wbiGuid);
            if (wbi == null)
            {
                return wbi;
            }
            else
            {
                
                wbi.NewRemarks = wbiVM.Description;
                wbi.NewEstimatedHours = wbiVM.EstimatedHours;
                wbi.NewActualHours = wbiVM.ActualHours;
               
                _context.SaveChanges();
            }
            return wbi;
        }
        public bool DeleteOneWBI(Guid id)
        {
            var wbi = GetOneWBI(id);
            if (wbi == null)
            {
                return false;
            }
            _context.NewChangeRequestExtensionBase.Remove(wbi);
            _context.SaveChanges();
            return true;
        }

    }
}
