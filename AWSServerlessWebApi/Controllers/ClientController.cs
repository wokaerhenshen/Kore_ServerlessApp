using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AWSServerlessWebApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("client")]
    public class ClientController : Controller
    {
        ClientRepo clientRepo;

        public ClientController(KORE_Interactive_MSCRMContext context)
        {
            clientRepo = new ClientRepo(context);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string Name)
        {
            if (Name == null || Name == "")
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Please provide a Client Name." });
            }

            ClientVM client = new ClientVM()
            {

                ClientName = Name,
                DeletionStateCode = ConstantDirectory.DeleteStateCodeDefault,
                StateCode = ConstantDirectory.StateCodeDefault
            };
            clientRepo.CreateClient(client);
            return new OkObjectResult(true);
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(clientRepo.GetAllClients());
        }

        [HttpGet]
        [Route("GetOneClient/{id}")]
        public IActionResult GetOneClient(string id)
        {
            if(id == null || id == "")
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Please provide a valid client id." });
            }

            Guid guid_id = Guid.Parse(id);
            return new OkObjectResult(clientRepo.GetOneClient(guid_id));
        }

        //update client
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(string id, string Name)
        {
            if(id == null || id == "")
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Please provide a valid client id." });
            }
            if(Name == null || Name == "")
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Please provide a valid client name." });
            }
            
            ClientVM client = new ClientVM()
            {
                ClientId = id,
                ClientName = Name                
            };
            clientRepo.UpdateOneClient(client);
            return new OkObjectResult(true);
        }

        //delete client
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            if(id == null || id == "")
            {
                return new BadRequestObjectResult(new { ErrorMessage = "Please provide a valid client id." });
            }
            Guid guid_id = Guid.Parse(id);
            clientRepo.DeleteOneClient(guid_id);

            return new OkObjectResult(true);
        }

    }
}