using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Repositories
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

            NewProjectTypeExtensionBase projectType = new NewProjectTypeExtensionBase()
            {
                NewProjectTypeId = Guid.NewGuid(),
                NewName = projectVM.ProjectType
            };
            NewProjectExtensionBase project = new NewProjectExtensionBase()
            {
                NewProjectId = Guid.NewGuid(),
                NewName = projectVM.ProjectName,
                NewStartDate = projectVM.StartDate,
                NewEndDate = projectVM.EndDate,
                NewProjectTypeId = projectType.NewProjectTypeId,
                NewAccountId = Guid.Parse(projectVM.ClientId)
            };


            _context.NewProjectTypeExtensionBase.Add(projectType);
            _context.SaveChanges();
            _context.NewProjectExtensionBase.Add(project);
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
                                             .Where(i => i.NewProjectId == Guid.Parse(projectVM.ProjectId))
                                             .FirstOrDefault();
            project.NewName = projectVM.ProjectName;
            project.NewStartDate = projectVM.StartDate;
            project.NewEndDate = projectVM.EndDate;
            //project.NewAccountId = Guid.Parse(projectVM.ClientId);

            //NewProjectTypeExtensionBase projectType = _context.NewProjectTypeExtensionBase
            //                                         .Where(u => u.NewProjectTypeId == project.NewProjectTypeId)
            //                                         .FirstOrDefault();
            //projectType.NewName = projectVM.ProjectType;

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
