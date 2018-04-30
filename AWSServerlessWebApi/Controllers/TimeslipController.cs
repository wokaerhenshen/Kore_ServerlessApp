using System;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public IActionResult Create([FromBody] TimeslipVM timeslipVM)
        {
            return new ObjectResult(timeslipRepo.CreateTimeslip(timeslipVM));
        }

        [HttpPost]
        [Route("CreateByCustomday")]
        public bool CreateByCustomday([FromBody] CustomDateVM customDateVM)
        {
            return timeslipRepo.CreateByCustomday(customDateVM);
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

        [HttpGet]
        [Route("GetAllTimeslipsByUserId/{id}")]
        public IActionResult GetAllTimeslipsByUserId(string id)
        {
            Guid userGuid = Guid.Parse(id);
            return new OkObjectResult(timeslipRepo.GetAllTimeslipsByUserId(userGuid));
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit([FromBody] TimeslipVM timeslipVM)
        {
            var timeslip = timeslipRepo.EditTimeslip(timeslipVM);
            if (timeslip == null)
            {
                return new NotFoundObjectResult(timeslip);
            }
            return new ObjectResult(timeslip);
        }
        //add a method to assign a timeslip to a custom day
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] DeleteTSVM timeslipId)
        {
           
            bool success = timeslipRepo.DeleteOneTimeslip(timeslipId.TimeSlipId);
            
            return new ObjectResult(success);
        }
    }
    
}