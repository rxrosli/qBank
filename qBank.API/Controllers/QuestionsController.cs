using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using qBank.API.DTO;
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
        private readonly IStatementRepository statementRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public QuestionsController(IQuestionRepository questionRepository, IStatementRepository statementRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }
        // GET api/questions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await questionRepository.GetQuestionsAsync();
            return Ok(questions);
        }

        // GET api/questions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(String id)
        {
            if (!QuestionIdExists(id)) return NoContent();
            var question = await questionRepository.GetQuestionByIdAsync(id);
            return Ok(question);
        }

        // POST api/questions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostQuestionDto questiondto)
        {
            mapper.Map<Question>(questiondto);
            await questionRepository.InsertQuestionAsync(mapper.Map<Question>(questiondto));
            return Ok();
        }

        // PUT api/questions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(String id, [FromBody] PostQuestionDto questiondto)
        {
            if (!QuestionIdExists(id)) return NoContent();
            var question = mapper.Map<Question>(questiondto);
            question.Id = id;
            await questionRepository.UpdateQuestionAsync(question);
            return Ok();

        }

        // DELETE api/questions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(String id)
        {
            if (!QuestionIdExists(id)) return NoContent();
            await questionRepository.DeleteQuestionAsync(id);
            return Ok();

        }

        // POST api/questions/{id}/statements
        [HttpPost("{id}/statements")]
        public async Task<IActionResult> AddQuestionStatement(string id, [FromBody] PostStatementDto statementdto)
        {
            if (!QuestionIdExists(id)) return NoContent();
            var question = await questionRepository.GetQuestionByIdAsync(id);
            question.Statements.Add(mapper.Map<Statement>(statementdto));
            await questionRepository.InsertQuestionAsync(question);
            return Ok();
        }

        // PUT api/questions/statements/{sid}
        [HttpPut("/statements/{id}")]
        public async Task<IActionResult> EditQuestionStatement(string id, [FromBody] PostStatementDto statementdto)
        {
            if (!StatementIdExists(id)) return NoContent();
            var statement = mapper.Map<Statement>(statementdto);
            statement.Id = id;
            await statementRepository.UpdateStatementAsync(statement);
            return Ok();
        }

        // DELETE api/questions/statements/{sid}
        [HttpDelete("/statements/{id}")]
        public async Task<IActionResult> DeleteQuestionStatement(string id)
        {
            if (!StatementIdExists(id)) return NoContent();
            await statementRepository.DeleteStatementAsync(id);
            return Ok();
        }

        // Utility
        protected bool QuestionIdExists(String id)
        {
            var exists = false;
            var exam = questionRepository.GetQuestionByIdAsync(id);
            if (exam != null) exists = true; 

            return exists;
        }

        protected bool StatementIdExists(String id)
        {
            var exists = false;
            var exam = statementRepository.GetByStatementIdAsync(id);
            if (exam != null) exists = true; 

            return exists;
        }

    }
}
