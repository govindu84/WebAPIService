using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult MultiRequestHAndler()
        {
            return Content( $"value of id ");
        }

        [HttpGet("{ids}")] //Adding int constarin to id
        public IActionResult Get(int ids)
        {
            return Ok($"value of id {ids} and value ");
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CustomerData value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { ids= value.id },value);

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

    public class CustomerData
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int id { get; set; }

        public string Name { get; set; }
    }
}
