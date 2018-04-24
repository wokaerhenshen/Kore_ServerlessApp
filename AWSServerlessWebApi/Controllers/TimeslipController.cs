using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using core_backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("timeslip")]
    public class TimeslipController : Controller
    {
        TimeslipRepo timeslipRepo;

        public TimeslipController(KORE_Interactive_MSCRMContext context)
        {
            timeslipRepo = new TimeslipRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TimeslipVM timeslipVM)
        {

            return new ObjectResult(timeslipRepo.CreateTimeslip(timeslipVM));
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new ObjectResult(timeslipRepo.GetAllTimeslips());
        }

        [HttpGet]
        [Route("GetOneTimeslip/{id}")]
        public IActionResult GetOneTimeslip(string id)
        {
            return new ObjectResult(timeslipRepo.GetOneTimeslip(id));
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(TimeslipVM timeslipVM)
        {
            var timeslip = timeslipRepo.EditTimeslip(timeslipVM);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            var timeslip = timeslipRepo.DeleteOneTimeslip(id);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }
    }
}