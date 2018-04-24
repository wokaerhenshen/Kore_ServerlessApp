using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
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
            
        }

    }
}
