using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Utility;
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

            Guid projectTypeGuid;
            NewProjectTypeExtensionBase currentProjectType = null;

            //if the input projectTypeId is a valid Guid, use it to search the database
            bool success = Guid.TryParse(projectVM.ProjectTypeId, out Guid result);
            //fix this
            if (success)
            {
                projectTypeGuid = result;

                //find existing project type in the database
                currentProjectType = _context.NewProjectTypeExtensionBase.Where(p => p.NewProjectTypeId == projectTypeGuid)
                   .FirstOrDefault();
            }
            //if the project type doesn't exist, use the default
            if (currentProjectType == null)
            {
                currentProjectType = _context.NewProjectTypeExtensionBase.Where(pt => pt.NewName == ConstantDirectory.ProjectTypeNameDefault).FirstOrDefault();

            }
            //if it still doesn't exist, create it
            if (currentProjectType == null)
            {
                currentProjectType = new NewProjectTypeExtensionBase()
                {
                    NewProjectTypeId = Guid.NewGuid(),
                    //assign the default name
                    NewName = ConstantDirectory.ProjectTypeNameDefault

                };
                _context.NewProjectTypeExtensionBase.Add(currentProjectType);
                _context.SaveChanges();
            } 

            NewProjectExtensionBase project = new NewProjectExtensionBase()
            {
                NewProjectId = Guid.NewGuid(),
                NewName = projectVM.ProjectName,
                NewStartDate = projectVM.StartDate,
                NewEndDate = projectVM.EndDate,
                NewProjectTypeId = currentProjectType.NewProjectTypeId,
                NewAccountId = Guid.Parse(projectVM.ClientId)
            };

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
