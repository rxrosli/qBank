using Microsoft.AspNetCore.Mvc;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qBank.API.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qBank.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        // GET api/exams
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var exams = await _examRepository.GetExamsAsync();
            return Ok(exams);
        }

        // GET api/exams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (IdExists(id))
            {
                var exam = await _examRepository.GetExamByIdAsync(id);
                return Ok(exam);
            }
            else { return NoContent(); }

        }

        // POST api/exams
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Exam exam)
        {
            await _examRepository.InsertExamAsync(exam);
            return Ok();
        }

        // PUT api/exams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Exam exam)
        {
            if (IdExists(id))
            {
                exam.ExamId = id;
                await _examRepository.UpdateExamAsync(exam);
                return Ok();
            }
            else { return NoContent(); }
        }

        // DELETE api/exams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (IdExists(id))
            {
                await _examRepository.DeleteExamAsync(id);
                return Ok();
            }
            else { return NoContent(); }
        }

        public bool IdExists(string id)
        {
            var exists = false;
            var exam = _examRepository.GetExamByIdAsync(id);
            if (exam != null) {exists = true;}

            return exists;
        }
    }
}
