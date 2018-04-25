﻿using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("customDay")]
    public class CustomDayController
    {
        CustomDayRepo customDayRepo;
        public CustomDayController(KORE_Interactive_MSCRMContext context)
        {
            customDayRepo = new CustomDayRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public bool Create(string Name, string Description)
        {
            return customDayRepo.CreateNewCustomDay(Name, Description);
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(customDayRepo.GetAllCustomDays());
        }

        [HttpGet]
        [Route("GetOneCustomDay/{id}")]
        public IActionResult GetOneCustomDay(int id)
        {
            return new OkObjectResult(customDayRepo.GetOneCustomDay(id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(int id, string Name, string Description)
        {
            return customDayRepo.UpdateCustomDay(id,Name, Description);
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int id)
        {
            return customDayRepo.DeleteCustomDay(id);
        }


        //Here is the answer to my question: Should timeslip include date?
        //answer: when we assign one timeslip to a customday, we can grab the 
        // start time and end time first, after that we can create a new 
        //time slip that when it is stroed as real timeslip to database.
        [HttpPost]
        [Route("AssignTimeSlip")]
        public bool AssignTimeSlip(int customDayId, Guid timeslipId)
        {
            return customDayRepo.AssignTimeSlip(customDayId, timeslipId);
        }

        [HttpDelete]
        [Route("DeleteTimeSlipInCustomDay")]
        public bool DeleteTimeSlipInCustomDay(int customDayId, Guid timeslipId)
        {
            return customDayRepo.DeleteTimeSlipInCustomDay(customDayId, timeslipId);
        }

    }
}
