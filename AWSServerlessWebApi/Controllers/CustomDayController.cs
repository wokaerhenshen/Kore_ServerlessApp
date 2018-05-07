using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("customDay")]
    public class CustomDayController
    {
        CustomDayRepo customDayRepo;
        public CustomDayController(KORE_Interactive_MSCRMContext context)
        {
            customDayRepo = new CustomDayRepo(context);
        }

        ///    <summary>Create one custom day.</summary>
        ///    <remarks>A "custom day" is a collection of timeslip templates for one 24-hour period.
        ///    To create, you must provide the UserId as a string which can be parsed as a Guid.</remarks>
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CustomDayVM customDayVM)
        {
            string userId = customDayVM.UserId;

            if(customDayVM == null)
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid CustomDayVM" });
            }
            if (userId == null || userId == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a UserId." });
            }
            Guid userGuid;
            bool success = Guid.TryParse(userId, out userGuid);
            if (success)
            {
                return new OkObjectResult(customDayRepo.CreateCustomDay(customDayVM));
            }
            return new BadRequestObjectResult(new { message = "UserId could not be parsed as a Guid" });  
        }
        ///    <summary>Returns a list of all custom days.</summary>
        ///    <remarks></remarks>
        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(customDayRepo.GetAllCustomDays());
        }

        [HttpGet]
        [Route("GetOneUserCustomDays/{id}")]
        public IActionResult GetOneUserCustomDays(string id)
        {
            if(id == null ||  id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a UserId" });
            }
           
            Guid userGuid;
            bool success = Guid.TryParse(id, out userGuid);
            if (success)
            {

                return new OkObjectResult(customDayRepo.GetOneUserCustomDays(id));
            }
            return new BadRequestObjectResult(new { message = "UserId could not be parsed as a Guid" });
            
        }

        [HttpGet]
        [Route("GetOneCustomDay/{id}")]
        public IActionResult GetOneCustomDay(string id)
        {
            if(id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid custom day id" });
            }

            return new OkObjectResult(customDayRepo.GetOneCustomDay(id));
        }
        
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CustomDayVM customDayVM)
        {
            if (customDayVM == null)
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid CustomDayVM" });
            }

            return new OkObjectResult(customDayRepo.UpdateCustomDay(customDayVM));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if(id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid custom day id" });
            }
            
            bool success = customDayRepo.DeleteCustomDay(id);
            if (!success)
            {
                return new BadRequestObjectResult(new { message = "An error occured when deleting a Custom Day." });
            }

            return new ObjectResult(success);
        }
        //Here is the answer to my question: Should timeslip include date?
        //answer: when we assign one timeslip to a customday, we can grab the 
        // start time and end time first, after that we can create a new 
        //time slip that when it is stroed as real timeslip to database.
        //[HttpPost]
        //[Route("AssignTimeSlip")]
        //public bool AssignTimeSlip(int customDayId, Guid timeslipId)
        //{
        //    return customDayRepo.AssignTimeSlip(customDayId, timeslipId);
        //}

        //[HttpDelete]
        //[Route("DeleteTimeSlipInCustomDay")]
        //public bool DeleteTimeSlipInCustomDay(int customDayId, Guid timeslipId)
        //{
        //    return customDayRepo.DeleteTimeSlipInCustomDay(customDayId, timeslipId);
        //}

    }
}
