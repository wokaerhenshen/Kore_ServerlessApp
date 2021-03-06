﻿using System;
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
        CustomDayRepo customDayRepo;
        TimeslipRepo timeslipRepo;
        UserRepo userRepo;
        public CustomDay_WBIController(KORE_Interactive_MSCRMContext context)
        {
            customDay_WBIRepo = new CustomDay_WBIRepo(context);
            timeslipRepo = new TimeslipRepo(context);
            userRepo = new UserRepo(context);
            customDayRepo = new CustomDayRepo(context);
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
                return new BadRequestObjectResult(new { message = "Please enter a start time" });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(customDay_WBIVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid start time" });
            }
            //check for end time null or empty
            if (customDay_WBIVM.EndTime == null || customDay_WBIVM.EndTime == "")
            {
                return new BadRequestObjectResult(new { message = "Please enter an end time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(customDay_WBIVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid end time" });
            }
            //check that start time is less than (earlier than) end time

            if (newStartTime >= newEndTime)
            {
                return new BadRequestObjectResult(new { message = "End time must be later than start time" });
            }
            //check that start time and end time are the same date
            if (newStartTime.Date != newEndTime.Date)
            {
                return new BadRequestObjectResult(new { message = "Start and end time must be the same date" });
            }
            //check for overlap with other timeslip templates
            var timeslipTemplates = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(customDay_WBIVM.CustomDayId);

            foreach (var item in timeslipTemplates)
            {
                if (item.TimeslipTemplateId != customDay_WBIVM.TimeslipTemplateId)
                {
                    if (item.StartTime.Hour < newEndTime.Hour && item.EndTime.Hour > newStartTime.Hour)
                    {
                        return new BadRequestObjectResult(new { message = "Times cannot overlap" });
                    }

                    if (item.StartTime.Hour == newEndTime.Hour)
                    {
                        if (item.StartTime.Minute < newEndTime.Minute)
                        {
                            return new BadRequestObjectResult(new { message = "Times cannot overlap" });
                        }
                    }

                    if (item.EndTime.Hour == newStartTime.Hour)
                    {
                        if (item.EndTime.Minute > newStartTime.Minute)
                        {
                            return new BadRequestObjectResult(new { message = "Times cannot overlap" });
                        }
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
        [Route("GetAllTimeslipTemplatesByCustomDayWithWBIName/{id}")]
        public IActionResult GetAllTimeslipTemplatesByCustomDayWithWBIName(string id)
        {
            if (id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid CustomDayId." });
            }

            var timeslipTemplateListWithWBIName = customDay_WBIRepo.GetAllTimeslipTemplatesByCustomDayWithWBIName(id);
            if (timeslipTemplateListWithWBIName == null || timeslipTemplateListWithWBIName.Count == 0)
            {
                return new BadRequestObjectResult(new { message = "There are no timeslip templates for this custom day" });
            }
            return new OkObjectResult(timeslipTemplateListWithWBIName);
        }

        [HttpGet]
        [Route("GetOneTimeslipTemplate/{id}")]
        public IActionResult GetOneTimeslipTemplate(string id)
        {
            return new OkObjectResult(customDay_WBIRepo.GetOneTimeslipTemplate(id));
        }

        [HttpPost]
        [Route("CreateAllTimeslipsUsingCustomDay")]
        public IActionResult CreateAllTimeslipsFromCustomDay([FromBody] CustomDateVM customDateVM)
        {
            //get the custom day (for the user ID)
            CustomDay customDay = customDayRepo.GetOneCustomDay(customDateVM.CustomdayId);
            //create a variable to store the date
            DateTime newDateTime;

            //check that date given is a valid datetime
            bool success1 = DateTime.TryParse(customDateVM.Date, out DateTime result1);
            if (success1)
            {
                newDateTime = result1;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid date" });
            }
            //get all the timeslips by user for a single date
            var userTimeslipsList = timeslipRepo.GetAllTimeslipsByUserIdWithDate(customDay.UserId, newDateTime);
            //get all timeslip templates by custom day
            var templateList = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(customDateVM.CustomdayId);

            foreach (var timeslip in userTimeslipsList)
            {
                foreach (var template in templateList)
                {
                    template.StartTime = new DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day, template.StartTime.Hour, template.StartTime.Minute, template.StartTime.Second);
                    template.EndTime = new DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day, template.EndTime.Hour, template.EndTime.Minute, template.EndTime.Second);
                    if (template.StartTime < timeslip.NewEndTask && template.EndTime > timeslip.NewStartTask)
                    {
                        return new BadRequestObjectResult(new { message = "One of the times in this custom day overlaps with an existing timeslip. Your request cannot be processed." });
                    }
                }
            }

            return new OkObjectResult(timeslipRepo.CreateTimeslipsByCustomDay(customDateVM));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CustomDay_WBIVM customDay_WBIVM)
        {
            DateTime newStartTime;
            DateTime newEndTime;

            if (customDay_WBIVM.TimeslipTemplateId == null || customDay_WBIVM.TimeslipTemplateId == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a TimeslipTemplateId" });
            }

            //check for start time null or empty
            if (customDay_WBIVM.StartTime == null || customDay_WBIVM.StartTime == "")
            {
                return new BadRequestObjectResult(new { message = "Please enter a start time" });
            }
            //check that start time is a valid datetime
            bool success1 = DateTime.TryParse(customDay_WBIVM.StartTime, out DateTime result1);
            if (success1)
            {
                newStartTime = result1;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid start time" });
            }
            //check for end time null or empty
            if (customDay_WBIVM.EndTime == null || customDay_WBIVM.EndTime == "")
            {
                return new BadRequestObjectResult(new { message = "Please enter an end time" });
            }
            //check that end time is a valid datetime
            bool success2 = DateTime.TryParse(customDay_WBIVM.EndTime, out DateTime result2);
            if (success2)
            {
                newEndTime = result2;
            }
            else
            {
                return new BadRequestObjectResult(new { message = "Please enter a valid end time" });
            }
            //check that start time is less than (earlier than) end time

            if (newStartTime >= newEndTime)
            {
                return new BadRequestObjectResult(new { message = "End time must be later than start time" });
            }
            //check that start time and end time are the same date
            if (newStartTime.Date != newEndTime.Date)
            {
                return new BadRequestObjectResult(new { message = "Start and end time must be the same date" });
            }

            var timeslipTemplate = customDay_WBIRepo.GetOneTimeslipTemplate(customDay_WBIVM.TimeslipTemplateId);

            //check for overlap with other timeslip templates
            var timeslipTemplates = customDay_WBIRepo.GetAllTimeslipTemplateByCustomDay(timeslipTemplate.CustomDayId);

            foreach (var item in timeslipTemplates)
            {
                if (item.TimeslipTemplateId != customDay_WBIVM.TimeslipTemplateId)
                {
                    if (item.StartTime < newEndTime && item.EndTime > newStartTime)
                    {
                        return new BadRequestObjectResult(new { message = "Times cannot overlap" });
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