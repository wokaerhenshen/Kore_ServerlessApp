using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using AWSServerlessWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using System.Web.Http;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet]
        [Route("GetOneProjectByWBIId/{id}")]
        public IActionResult GetOneProjectByWBIId(string id)
        {
            Guid guid_id = Guid.Parse(id);
            return new OkObjectResult(projectRepo.GetOneProjectByWBIId(guid_id));
        }


        [HttpGet]
        [Route("GetAllProjectsByClientId/{id}")]
        public IActionResult GetAllProjectsByClientId(string id)
        {
            Guid clientGuid = Guid.Parse(id);
            return new OkObjectResult(projectRepo.GetAllProjectsByClientId(clientGuid));
        }
        [HttpGet]
        [Route("GetAllProjectTypes")]
        public IActionResult GetAllProjectTypes()
        {
            return new OkObjectResult(projectRepo.GetAllProjectTypes());
        }
        [HttpPut]
        [Route("Update")]
        public bool Update([FromBody] ProjectVM Project)
        {
            projectRepo.UpdateOneProject(Project);
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool Delete(string id)
        {
            Guid guid_id = Guid.Parse(id);

            projectRepo.DeleteOneProject(guid_id);
            return true;
        }
    }

}