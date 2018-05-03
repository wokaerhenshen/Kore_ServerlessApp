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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("timeslip")]
    public class TimeslipController : Controller
    {
        TimeslipRepo timeslipRepo;
        WBIRepo wbiRepo;

        public TimeslipController(KORE_Interactive_MSCRMContext context)
        {
            timeslipRepo = new TimeslipRepo(context);
            wbiRepo = new WBIRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TimeslipVM timeslipVM)
        {
            //check if the view model being passed is null
            if (timeslipVM == null)
            {
                return new BadRequestObjectResult(new { message = "Invalid timeslip view model" });
            }

            DateTime newStartTime;
            DateTime newEndTime;

            //check if the dates are null
            if ((timeslipVM.StartTime == null || timeslipVM.StartTime == "") || 
                (timeslipVM.EndTime == null || timeslipVM.EndTime == ""))
            {
                return new BadRequestObjectResult(new { message = "Invalid time input. Please enter a valid time." });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(timeslipVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid start time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(timeslipVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid end time" });
            }
            //check if the user id is null
            if (timeslipVM.UserId == null || timeslipVM.UserId == "")
            {
                return new BadRequestObjectResult(new { message = "Invalid user. Please log in." });
            }
            //check if the wbi id is null
            if (timeslipVM.WBI_Id == null || timeslipVM.WBI_Id == "")
            {
                return new BadRequestObjectResult(new { message = "Please enter a Work Breakdown Item." });
            }
            //check if the end time is earlier than start time
            if (newStartTime >= newEndTime)
            {
                return new BadRequestObjectResult(new { message = "Invalid time input. End time should be later that start time." });
            }
            //check to make sure the actual hours do not exceed the estimated hours
            TimeSpan? duration = Convert.ToDateTime(timeslipVM.EndTime) - Convert.ToDateTime(timeslipVM.StartTime);
            int durationInHours = (int)duration?.TotalHours;
            Guid wbiGuid = Guid.Parse(timeslipVM.WBI_Id);
            var wbi = wbiRepo.GetOneWBI(wbiGuid);
            int? localActualHours = wbi.NewActualHours;
            localActualHours += durationInHours;
            if (localActualHours > wbi.NewEstimatedHours)
            {
                return new BadRequestObjectResult(new { message = "Alloted hours for this WBI has been maxed out." });
            }
            //check to make sure two timeslips do not overlap
            Guid userGuid = Guid.Parse(timeslipVM.UserId);
            var timeslipListByUserId = timeslipRepo.GetAllTimeslipsByUserId(userGuid);
            var date = Convert.ToDateTime(timeslipVM.StartTime);
            var sameDate = date.Date;
            var timeslipListByUserIdOnTheSameDay = timeslipListByUserId.Where(u => Convert.ToDateTime(u.NewStartTask).Date == sameDate);
            foreach (var item in timeslipListByUserIdOnTheSameDay)
            {
                    if (item.NewStartTask <= Convert.ToDateTime(timeslipVM.EndTime) && 
                        item.NewEndTask >= Convert.ToDateTime(timeslipVM.StartTime))
                    {
                        return new BadRequestObjectResult(new { message = "Times cannot overlap" });
                    }
            }           

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
            //check if the view model being passed is null
            if (timeslipVM == null)
            {
                return new BadRequestObjectResult(new { message = "Invalid timeslip view model" });
            }

            DateTime newStartTime;
            DateTime newEndTime;

            //check if the dates are null
            if ((timeslipVM.StartTime == null || timeslipVM.StartTime == "") ||
                (timeslipVM.EndTime == null || timeslipVM.EndTime == ""))
            {
                return new BadRequestObjectResult(new { message = "Invalid time input. Please enter a valid time." });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(timeslipVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid start time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(timeslipVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid end time" });
            }
            //check if the user id is null
            if (timeslipVM.UserId == null || timeslipVM.UserId == "")
            {
                return new BadRequestObjectResult(new { message = "Invalid user. Please log in." });
            }
            //check if the wbi id is null
            if (timeslipVM.WBI_Id == null || timeslipVM.WBI_Id == "")
            {
                return new BadRequestObjectResult(new { message = "Please enter a Work Breakdown Item." });
            }
            //check if the end time is earlier than start time
            if (newStartTime >= newEndTime)
            {
                return new BadRequestObjectResult(new { message = "Invalid time input. End time should be later that start time." });
            }
            //check to make sure the actual hours do not exceed the estimated hours
            TimeSpan? duration = Convert.ToDateTime(timeslipVM.EndTime) - Convert.ToDateTime(timeslipVM.StartTime);
            int durationInHours = (int)duration?.TotalHours;
            Guid wbiGuid = Guid.Parse(timeslipVM.WBI_Id);
            var wbi = wbiRepo.GetOneWBI(wbiGuid);
            int? localActualHours = wbi.NewActualHours;
            localActualHours += durationInHours;
            if (localActualHours > wbi.NewEstimatedHours)
            {
                return new BadRequestObjectResult(new { message = "Alloted hours for this WBI has been maxed out." });
            }
            //check to make sure two timeslips do not overlap
            Guid userGuid = Guid.Parse(timeslipVM.UserId);
            var timeslipListByUserId = timeslipRepo.GetAllTimeslipsByUserId(userGuid);
            var date = Convert.ToDateTime(timeslipVM.StartTime);
            var sameDate = date.Date;
            var timeslipListByUserIdOnTheSameDay = timeslipListByUserId.Where(u => Convert.ToDateTime(u.NewStartTask).Date == sameDate);
            foreach (var item in timeslipListByUserIdOnTheSameDay)
            {
                if (item.NewStartTask <= Convert.ToDateTime(timeslipVM.EndTime) &&
                    item.NewEndTask >= Convert.ToDateTime(timeslipVM.StartTime))
                {
                    return new BadRequestObjectResult(new { message = "Times cannot overlap" });
                }
            }

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

            if(success)
            {
                return new ObjectResult(success);
            }else
            {
                return new BadRequestObjectResult(new { message = "An error occured when deleting a timeslip." });
            }
           
        }
    }
    
}