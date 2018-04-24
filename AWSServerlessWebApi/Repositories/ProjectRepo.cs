﻿using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Utility;

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
            //convert project type id from string to Guid
            Guid projectTypeGuid = Guid.Parse(projectVM.ProjectTypeId);
            //find existing project type in the database
            NewProjectTypeExtensionBase currentProjectType = _context.NewProjectTypeExtensionBase.Where(p => p.NewProjectTypeId == projectTypeGuid)
                .FirstOrDefault();
            //if the project type doesn't exist, create it
            if(currentProjectType == null)
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
                NewAccountId = projectVM.ClientId
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
                                             .Where(i => i.NewProjectId == projectVM.ProjectId)
                                             .FirstOrDefault();
            project.NewName = projectVM.ProjectName;
            project.NewStartDate = projectVM.StartDate;
            project.NewEndDate = projectVM.EndDate;
            project.NewAccountId = projectVM.ClientId;

            NewProjectTypeExtensionBase projectType = _context.NewProjectTypeExtensionBase
                                                     .Where(u => u.NewProjectTypeId == project.NewProjectTypeId)
                                                     .FirstOrDefault();
//            projectType.NewName = projectVM.ProjectTypeName;

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
