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
    public class ExamsController : ControllerBase
    {
        // GET api/exams
        [HttpGet]
        public IEnumerable<Exam> Get()
        {
            return new List<Exam>();
        }

        // GET api/exams/{id}
        [HttpGet("{id}")]
        public Exam Get(String id)
        {
            return new Exam();
        }

        // POST api/exams
        [HttpPost]
        public void Post([FromBody] Exam value)
        {

        }

        // PUT api/exams/{id}
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Exam value)
        {

        }

        // DELETE api/exams/{id}
        [HttpDelete("{id}")]
        public void Delete(String id)
        {

        }
    }
}
