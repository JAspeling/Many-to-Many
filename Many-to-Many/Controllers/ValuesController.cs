using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManytoMany;
using ManytoMany.Models;
using Microsoft.AspNetCore.Mvc;

namespace Many_to_Many.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public MyDbContext Context { get; }

        public ValuesController(MyDbContext context) {
            Context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var person = new Person("Gerhard", "Aspeling");

            var existing = Context.People.Find(1);

            person.Friends.Add(existing);

            //existing.Friends.Add(person);

            Context.People.Add(person);
            Context.SaveChanges();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
