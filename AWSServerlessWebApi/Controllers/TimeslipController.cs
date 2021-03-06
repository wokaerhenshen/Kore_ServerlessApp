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
                if (item.NewStartTask < Convert.ToDateTime(timeslipVM.EndTime) &&
                    item.NewEndTask > Convert.ToDateTime(timeslipVM.StartTime))
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
            if (id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid timeslip id." });
            }

            return new ObjectResult(timeslipRepo.GetOneTimeslip(id));
        }
        [HttpGet]
        [Route("GetAllTimeslipsByWBIId/{id}")]
        public IActionResult GetAllTimeslipsByWBIId(string id)
        {
            if (id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid user id." });
            }
            Guid wbiGuid;
            bool success = Guid.TryParse(id, out wbiGuid);
            if (success)
            {
                var timeslipList = timeslipRepo.GetAllTimeslipsByWbiId(wbiGuid);
                if (timeslipList == null || timeslipList.Count == 0)
                {
                    return new OkObjectResult("There are no timeslips for this user");
                }
                return new OkObjectResult(timeslipList);
            }
            return new BadRequestObjectResult(new { message = "id could not be parsed as a Guid" });
        }

        [HttpGet]
        [Route("GetAllTimeslipsByUserId/{id}")]
        public IActionResult GetAllTimeslipsByUserId(string id)
        {
            if (id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid user id." });
            }
            Guid userGuid;
            bool success = Guid.TryParse(id, out userGuid);
            if (success)
            {
                var timeslipList = timeslipRepo.GetAllTimeslipsByUserId(userGuid);
                if (timeslipList == null || timeslipList.Count == 0)
                {
                    return new OkObjectResult("There are no timeslips for this user");
                }
                return new OkObjectResult(timeslipList);
            }
            return new BadRequestObjectResult(new { message = "id could not be parsed as a Guid" });

        }

        [HttpGet]
        [Route("GetAllTimeslipsByUserIdWithWBIName/{id}")]
        public IActionResult GetAllTimeslipsByUserIdWithWBIName(string id)
        {
            if (id == null || id == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid user id." });
            }
            Guid userGuid;
            bool success = Guid.TryParse(id, out userGuid);
            if (success)
            {
                var timeslipListWithWBIName = timeslipRepo.GetAllTimeslipsByUserIdWithWBIName(userGuid);
                if (timeslipListWithWBIName == null || timeslipListWithWBIName.Count == 0)
                {
                    return new OkObjectResult("There are no timeslips for this user");
                }
                return new OkObjectResult(timeslipListWithWBIName);
            }
            return new BadRequestObjectResult(new { message = "id could not be parsed as a Guid" });

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

            //check if the end time is earlier than start time
            if (newStartTime >= newEndTime)
            {
                return new BadRequestObjectResult(new { message = "Invalid time input. End time should be later that start time." });
            }
            //check to make sure the actual hours do not exceed the estimated hours
            TimeSpan? duration = Convert.ToDateTime(timeslipVM.EndTime) - Convert.ToDateTime(timeslipVM.StartTime);
            int durationInHours = (int)duration?.TotalHours;
            var tempWBI_Id = timeslipRepo.GetOneTimeslip(timeslipVM.TimeslipId).NewChangeRequestId.ToString();
            Guid wbiGuid = Guid.Parse(tempWBI_Id);
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
            Guid timeslipGuid = Guid.Parse(timeslipVM.TimeslipId);
            //this makes sure to exclude the same timeslip when validating overlaps
            var timeslipListByUserIdOnTheSameDay = timeslipListByUserId.Where(u => Convert.ToDateTime(u.NewStartTask).Date == sameDate)
                                                                       .Where(i => i.NewTimesheetEntryId != timeslipGuid);
            foreach (var item in timeslipListByUserIdOnTheSameDay)
            {
                if (item.NewStartTask < Convert.ToDateTime(timeslipVM.EndTime) &&
                    item.NewEndTask > Convert.ToDateTime(timeslipVM.StartTime))
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

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] DeleteTSVM timeslipId)
        {
            //check if the view model is null
            if (timeslipId == null)
            {
                return new BadRequestObjectResult(new { message = "Invalid DeleteTSVM. View model cannot be null" });
            }
            //check if the timeslip id is null or has empty string
            if (timeslipId.TimeSlipId == null || timeslipId.TimeSlipId == "")
            {
                return new BadRequestObjectResult(new { message = "Please provide a valid timeslip id." });
            }

            bool success = timeslipRepo.DeleteOneTimeslip(timeslipId.TimeSlipId);
            if (!success)
            {
                return new BadRequestObjectResult(new { message = "An error occured when deleting a timeslip." });
            }

            return new ObjectResult(success);
        }
    }

}