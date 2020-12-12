using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarsAPI.Controllers.Star
{
    /// <summary>
    /// 星系的控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StarsController : Controller
    {
        // GET: api/<StarsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StarsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
