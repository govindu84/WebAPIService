using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIService.Controller
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        //GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/MultiAction
        [Route("[Action]")]
        [ActionName("MultiAction")] //custom name to action
        [AcceptVerbs("POST", "GET")] //Accepting multiple verbs
        public string MultiRequestHAndler()
        {
            return $"value of id ";
        }

        [HttpGet("{id:int}/{value}")] //Adding int constarin to id
        public string Get(int id, string value)
        {
            return $"value of id {id} and value {value}";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id?}")] //Adding optional id
        public void Delete(int id)
        {
        }
    }
}
