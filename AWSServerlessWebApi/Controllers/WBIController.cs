using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using core_backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;

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
        public IActionResult Create(WBIVM wbiVM)
        {
            return new OkObjectResult(wbiRepo.CreateWBI(wbiVM));
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(wbiRepo.GetAllWBIs());
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
        public IActionResult Edit(WBIVM wbiVM)
        {
            var wbi = wbiRepo.EditWBI(wbiVM);
            if (wbi == null)
            {
                return new NotFoundObjectResult(wbi);
            }
            return new OkObjectResult(wbi);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            var success = wbiRepo.DeleteOneWBI(guid);
            return new ObjectResult(success);
        }
    }
}