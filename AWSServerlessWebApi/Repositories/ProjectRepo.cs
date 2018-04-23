using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_backend.Repositories
{
    public class ProjectRepo
    {

        KORE_Interactive_MSCRMContext _context;

        public ProjectRepo (KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public void CreateProject(ProjectVM projectVM)
        {
            NewProjectExtensionBase project = new NewProjectExtensionBase()
            {
                NewName = projectVM.ProjectName,
                NewStartDate = projectVM.StartDate,
                NewEndDate = projectVM.EndDate,
                NewAccountId = projectVM.ClientId
            };
            NewProjectTypeExtensionBase projectType = new NewProjectTypeExtensionBase()
            {
                NewName = projectVM.ProjectType
            };

            _context.NewProjectExtensionBase.Add(project);
            _context.NewProjectTypeExtensionBase.Add(projectType);
            _context.SaveChanges();
        }

        public List<NewProjectExtensionBase> GetAllProjects()
        {
            return _context.NewProjectExtensionBase.ToList();
        }

        public NewProjectExtensionBase GetOneProject(Guid id)
        {
            return _context.NewProjectExtensionBase.Where(i => i.NewProjectId == id).FirstOrDefault();
        }

        public void UpdateOneProject(ProjectVM projectVM)
        {
            NewProjectExtensionBase project = _context.NewProjectExtensionBase
                                             .Where(i => i.NewProjectId == projectVM.ProjectId)
                                             .FirstOrDefault();
            project.NewName = projectVM.ProjectName;
            project.NewStartDate = projectVM.StartDate;
            project.NewEndDate = projectVM.EndDate;
            project.NewAccountId = projectVM.ClientId;

            NewProjectTypeExtensionBase projectType = _context.NewProjectTypeExtensionBase
                                                     .Where(u => u.NewProjectTypeId == project.NewProjectTypeId)
                                                     .FirstOrDefault();
            projectType.NewName = projectVM.ProjectType;

            _context.SaveChanges();
        }

        public void DeleteOneProject(Guid id)
        {
            NewProjectExtensionBase project = _context.NewProjectExtensionBase
                                              .Where(i => i.NewProjectId == id).FirstOrDefault();

            NewProjectTypeExtensionBase projectType = _context.NewProjectTypeExtensionBase
                                                      .Where(u => u.NewProjectTypeId == project.NewProjectTypeId)
                                                      .FirstOrDefault();

            _context.NewProjectExtensionBase.Remove(project);
            _context.NewProjectTypeExtensionBase.Remove(projectType);
            _context.SaveChanges();
        }
    }
}
