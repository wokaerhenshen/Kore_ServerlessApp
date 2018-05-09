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

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CustomDayVM customDayVM)
        {
            string userId = customDayVM.UserId;

            if (customDayVM == null)
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
            if (id == null || id == "")
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
            if (id == null || id == "")
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
            if (id == null || id == "")
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
    }
}
