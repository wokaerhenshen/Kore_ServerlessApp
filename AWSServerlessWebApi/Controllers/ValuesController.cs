using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
//using AWSServerlessWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        KORE_Interactive_MSCRMContext _context;

        public ValuesController(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            NewProjectTypeExtensionBase PT = new NewProjectTypeExtensionBase()
            {
                NewProjectTypeId = Guid.NewGuid(),
                NewName = "karl"
            };
            _context.NewProjectTypeExtensionBase.Add(PT);
            _context.SaveChanges();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
