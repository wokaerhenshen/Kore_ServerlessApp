﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AWSServerlessWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using AWSServerlessWebApi.Models;

using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("wbi")]
    public class WBIController : Controller
    {
        WBIRepo wbiRepo;

        public WBIController(KORE_Interactive_MSCRMContext context)
        {
            wbiRepo = new WBIRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] WBIVM wbiVM)
        {
            if (wbiVM.EstimatedHours <= 0)
            {
                return new BadRequestObjectResult(new { message = "Estimated hours cannot be less than or equal to zero" });
            }
            if (wbiVM.ProjectId == null || wbiVM.ProjectId == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a ProjectId" });
            }

            Guid result;
            bool success = Guid.TryParse(wbiVM.ProjectId, out result);
            if (success)
            {
                return new OkObjectResult(wbiRepo.CreateWBI(wbiVM));
            }
            return new BadRequestObjectResult(new { message = "ProjectId must be parsed into a valid Guid" });
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(wbiRepo.GetAllWBIs());
        }
        [HttpGet]
        [Route("GetAllWBIsByProjectId/{id}")]
        public IActionResult GetAllWBIsByProjectId(string id)
        {
            Guid projectGuid = Guid.Parse(id);
            return new OkObjectResult(wbiRepo.GetAllWBIsByProjectId(projectGuid));
        }

        [HttpGet]
        [Route("GetWBIBySearchString/{id}")]
        public IActionResult GetWBIBySearchString(string id)
        {
            return new OkObjectResult(wbiRepo.GetWBIBySearchString(id));
        }


        [HttpGet]
        [Route("GetOneWBI/{id}")]
        public IActionResult GetOneWBI(string id)
        {
            Guid guid = Guid.Parse(id);
            return new OkObjectResult(wbiRepo.GetOneWBI(guid));
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit([FromBody]WBIVM wbiVM)
        {
            var wbi = wbiRepo.EditWBI(wbiVM);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            var success = wbiRepo.DeleteOneWBI(guid);
            return new ObjectResult(success);
        }
    }
}