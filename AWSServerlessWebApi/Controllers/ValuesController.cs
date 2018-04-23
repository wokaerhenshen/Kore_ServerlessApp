using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AWSServerlessWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        //ApplicationDbContext _context;

        //public ValuesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Name name = new Name()
            //{
            //    firstName = "Karl"
            //};
            //_context.Name.Add(name);
            //_context.SaveChanges();

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
