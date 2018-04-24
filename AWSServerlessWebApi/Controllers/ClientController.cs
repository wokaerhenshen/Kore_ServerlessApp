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
        public bool Create(string Name, int DeletionStateCode, int StateCode)
        {
            ClientVM client = new ClientVM()
            {
                ClientName = Name,
                DeletionStateCode = DeletionStateCode,
                StateCode = StateCode
            };

            clientRepo.CreateClient(client);
            return true;
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
            Guid guid_id = Guid.Parse(id);

            return new OkObjectResult(clientRepo.GetOneClient(guid_id));
        }

        //update client
        [HttpPut]
        [Route("Update")]
        public bool Update(string id, string Name, int DeletionStateCode, int StateCode)
        {
            Guid guid_id = Guid.Parse(id);

            ClientVM client = new ClientVM()
            {
                ClientId = guid_id,
                ClientName = Name,
                DeletionStateCode = DeletionStateCode,
                StateCode = StateCode
            };

            clientRepo.UpdateOneClient(client);
            return true;
        }

        //delete client
        [HttpDelete]
        [Route("Delete")]
        public bool Delete(string id)
        {
            Guid guid_id = Guid.Parse(id);

            clientRepo.DeleteOneClient(guid_id);
            return true;
        }

    }
}