using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using AWSServerlessWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

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
        public bool Create([FromBody] ProjectVM Project)
        {            
            projectRepo.CreateProject(Project);
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
        public bool Update([FromBody] ProjectVM Project)
        {
            projectRepo.UpdateOneProject(Project);
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