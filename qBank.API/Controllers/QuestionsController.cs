using Microsoft.AspNetCore.Mvc;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        // GET: api/questions
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return new List<Question>();
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public Question Get(String id)
        {
            return new Question();
        }

        // POST api/questions
        [HttpPost]
        public void Post([FromBody] Question value)
        {
        }

        // PUT api/questions/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Question value)
        {
        }

        // DELETE api/questions/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
        }
    }
}
