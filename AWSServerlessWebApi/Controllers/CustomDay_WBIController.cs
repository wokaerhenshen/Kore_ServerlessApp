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
        TimeslipRepo timeslipRepo;

        public CustomDay_WBIController(KORE_Interactive_MSCRMContext context)
        {
            customDay_WBIRepo = new CustomDay_WBIRepo(context);
            timeslipRepo = new TimeslipRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CustomDay_WBIVM customDay_WBIVM)
        {
            DateTime newStartTime;
            DateTime newEndTime;

            //check for start time null or empty
            if (customDay_WBIVM.StartTime == null || customDay_WBIVM.StartTime == "")
            {
                return  BadRequest(new { message = "Please enter a valid start time" });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(customDay_WBIVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            } else
            {
                return new JsonResult(new { message = "Please enter a valid start time" });
            }
            //check for end time null or empty
            if (customDay_WBIVM.EndTime == null || customDay_WBIVM.EndTime == "")
            {
                return new JsonResult(new { message = "Please enter an end time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(customDay_WBIVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new JsonResult(new { message = "Please enter a valid end time" });
            }
            //check that start time is less than (earlier than) end time

            if(newStartTime >= newEndTime)
            {
                return new JsonResult(new { message = "End time must be later than start time" });
            }
            //check that start time and end time are the same date
            if(newStartTime.Date != newEndTime.Date)
            {
                return new JsonResult(new { message = "Start and end time must be the same date" });
            }
            //check for overlap with other timeslip templates
            var timeslipTemplates = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(customDay_WBIVM.CustomDayId);

            foreach (var item in timeslipTemplates)
            {
                if (item.TimeslipTemplateId != customDay_WBIVM.TimeslipTemplateId)
                {
                    if (item.StartTime <= newEndTime && item.EndTime >= newStartTime)
                    {
                        return BadRequest(new { message = "Times cannot overlap" });
                    }
                }
            }

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

        [HttpPost]
        [Route("CreateAllTimeslipsUsingCustomDay")]
        public bool CreateAllTimeslipsFromCustomDay([FromBody] CustomDateVM customDateVM)
        {
            timeslipRepo.CreateTimeslipsByCustomDay(customDateVM);
            return true;
           
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CustomDay_WBIVM customDay_WBIVM)
        {
            DateTime newStartTime;
            DateTime newEndTime;

            if (customDay_WBIVM.TimeslipTemplateId == null || customDay_WBIVM.TimeslipTemplateId == "")
            {
                return new JsonResult(new { message = "Please provide a TimeslipTemplateId" });
            }

            //check for start time null or empty
            if (customDay_WBIVM.StartTime == null || customDay_WBIVM.StartTime == "")
            {
                return new JsonResult(new { message = "Please enter a start time" });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(customDay_WBIVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            }
            else
            {
                return new JsonResult(new { message = "Please enter a valid start time" });
            }
            //check for end time null or empty
            if (customDay_WBIVM.EndTime == null || customDay_WBIVM.EndTime == "")
            {
                return new JsonResult(new { message = "Please enter an end time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(customDay_WBIVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new JsonResult(new { message = "Please enter a valid end time" });
            }
            //check that start time is less than (earlier than) end time

            if (newStartTime >= newEndTime)
            {
                return new JsonResult(new { message = "End time must be later than start time" });
            }
            //check that start time and end time are the same date
            if (newStartTime.Date != newEndTime.Date)
            {
                return new JsonResult(new { message = "Start and end time must be the same date" });
            }
            //check for overlap with other timeslip templates
            var timeslipTemplates = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(customDay_WBIVM.CustomDayId);

            foreach (var item in timeslipTemplates)
            {
                if (item.TimeslipTemplateId != customDay_WBIVM.TimeslipTemplateId)
                {
                    if (item.StartTime <= newEndTime && item.EndTime >= newStartTime)
                    {
                        return new JsonResult(new { message = "Times cannot overlap" });
                    }
                }
            }
            return new OkObjectResult(customDay_WBIRepo.EditTimeslipTemplate(customDay_WBIVM));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool Delete(string id)
        {
            return customDay_WBIRepo.DeleteOneTimeslipTemplate(id);
        }
    }
}