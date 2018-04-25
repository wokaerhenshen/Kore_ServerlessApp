using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        UserRepo userRepo;

        public UserController(KORE_Interactive_MSCRMContext context)
        {
            userRepo = new UserRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public bool Create(string Email, string Password, string FirstName, string LastName)
        {
            UserVM user = new UserVM()
            {
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };

            userRepo.CreateUser(user);
            return true;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(userRepo.GetAllUsers());
        }

        [HttpGet]
        [Route("GetOneUser/{id}")]
        public IActionResult GetOneUser(string id)
        {
            Guid guid_id = Guid.Parse(id);

            return new OkObjectResult(userRepo.GetOneUser(guid_id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(string Id, string Email, string Password, string FirstName, string LastName)
        {
            

            UserVM user = new UserVM()
            {
                UserId = Id,
                Email = Email,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };

            userRepo.UpdateOneUser(user);
            return true;
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(string id)
        {
            Guid guid_id = Guid.Parse(id);

            userRepo.DeleteOneUser(guid_id);
            return true;
        }
    }
}
