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
        private readonly IExamRepository examRepository;
        private readonly IQuestionRepository questionRepository;

        public ExamsController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }

        // GET api/exams
        // TODO: Add pagination
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exams = await examRepository.GetExamsAsync();
            return Ok(exams);
        }

        // GET api/exams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (IdExists(id))
            {
                var exam = await examRepository.GetExamByIdAsync(id);
                return Ok(exam);
            }
            else { return NoContent(); }
        }

        // GET api/exams/{id}
        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetAllQuestions(string id)
        {
            if (!IdExists(id)) return NoContent();

            var questions = await questionRepository.GetAllQuestionsByExamId(id);
            return Ok(questions);
        }

        // POST api/exams
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Exam exam)
        {
            await examRepository.InsertExamAsync(exam);
            return Ok();
        }

        // PUT api/exams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Exam exam)
        {
            if (IdExists(id))
            {
                exam.ExamId = id;
                await examRepository.UpdateExamAsync(exam);
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
                await examRepository.DeleteExamAsync(id);
                return Ok();
            }
            else { return NoContent(); }
        }

        protected bool IdExists(string id)
        {
            var exists = false;
            var exam = examRepository.GetExamByIdAsync(id);
            if (exam != null) {exists = true;}

            return exists;
        }
    }
}
