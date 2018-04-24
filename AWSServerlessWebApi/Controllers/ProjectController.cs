using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using core_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("project")]
    public class ProjectController : Controller
    {
        ProjectRepo projectRepo;

        public ProjectController(KORE_Interactive_MSCRMContext context)
        {
            projectRepo = new ProjectRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public bool Create(string Name, string StartDate, string EndDate, string ProjectType)
        {
            ProjectVM project = new ProjectVM()
            {
                ProjectName = Name,
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate),
                ProjectType = ProjectType
            };
            
            projectRepo.CreateProject(project);
            return true;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(projectRepo.GetAllProjects());
        }

        [HttpGet]
        [Route("GetOneProject/{id}")]
        public IActionResult GetOneProject(string id)
        {
            Guid guid_id = Guid.Parse(id);

            return new OkObjectResult(projectRepo.GetOneProject(guid_id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(string id, string Name, string StartDate, string EndDate, string ProjectType)
        {
            Guid guid_id = Guid.Parse(id);

            ProjectVM project = new ProjectVM()
            {
                ProjectId = guid_id,
                ProjectName = Name,
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate),
                ProjectType = ProjectType
            };

            projectRepo.UpdateOneProject(project);
            return true;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(string id)
        {
            Guid guid_id = Guid.Parse(id);

            projectRepo.DeleteOneProject(guid_id);
            return true;
        }
    }
}