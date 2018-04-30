using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("customDay_WBI")]
    public class CustomDay_WBIController : Controller
    {
        CustomDay_WBIRepo customDay_WBIRepo;
        public CustomDay_WBIController(KORE_Interactive_MSCRMContext context)
        {
            customDay_WBIRepo = new CustomDay_WBIRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CustomDay_WBIVM customDay_WBIVM)
        {
            return new OkObjectResult(customDay_WBIRepo.CreateTimeslipTemplate(customDay_WBIVM));
        }

        [HttpGet]
        [Route("GetAllTimeslipTemplateByCustomDay/{id}")]
        public IActionResult GetAllTimeslipTemplateByCustomDay(string id)
        {
            return new OkObjectResult(customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(id));
        }

        [HttpGet]
        [Route("GetOneTimeslipTemplate/{id}")]
        public IActionResult GetOneTimeslipTemplate(string id)
        {
            return new OkObjectResult(customDay_WBIRepo.GetOneTimeslipTemplate(id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update([FromBody] CustomDay_WBIVM customDay_WBIVM)
        {
            return customDay_WBIRepo.EditTimeslipTemplate(customDay_WBIVM);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool Delete(string id)
        {
            return customDay_WBIRepo.DeleteOneTimeslipTemplate(id);
        }
    }
}