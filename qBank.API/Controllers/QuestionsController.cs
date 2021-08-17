using Microsoft.AspNetCore.Mvc;
using qBank.API.Repository.Interfaces;
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
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        // GET: api/questions
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var questions = await _questionRepository.GetQuestionsAsync();
            return Ok(questions);
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(String id)
        {
            if (IdExists(id))
            {
                var question = await _questionRepository.GetQuestionByIdAsync(id);
                return Ok(question);
            }
            else { return NoContent(); }

        }

        // POST api/questions
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Question question)
        {
            await _questionRepository.InsertQuestionAsync(question);
            return Ok();
        }

        // PUT api/questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(String id, [FromBody] Question question)
        {
            if (IdExists(id))
            {
                question.QuestionId = id;
                await _questionRepository.UpdateQuestionAsync(question);
                return Ok();
            }
            else { return NoContent(); }
        }

        // DELETE api/questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(String id)
        {
            if (IdExists(id))
            {
                await _questionRepository.DeleteQuestionAsync(id);
                return Ok();
            }
            else { return NoContent(); }
        }

        public bool IdExists(String id)
        {
            var exists = false;
            var exam = _questionRepository.GetQuestionByIdAsync(id);
            if (exam != null) { exists = true; }

            return exists;
        }
    }
}
