using Microsoft.AspNetCore.Mvc;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qBank.API.Repository.Interfaces;
using AutoMapper;
using qBank.API.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace qBank.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository examRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public ExamsController(IExamRepository examRepository, IQuestionRepository questionRepository, IMapper mapper)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        // GET api/exams
        // TODO: Add pagination
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exams = await examRepository.GetExamsAsync();
            var examdtos =  exams.Aggregate(new List<GetExamsDto>(), (dto, exam) => 
            {
                dto.Add(mapper.Map<GetExamsDto>(exam)); return dto;
            });
            return Ok(examdtos);
        }

        // GET api/exams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (IdExists(id))
            {
                var exam = await examRepository.GetExamByIdAsync(id);
                return Ok(exam);
            }
            else { return NoContent(); }
        }

        // POST api/exams
        [HttpPost]
        public async Task<IActionResult> Post(PostExamDto examdto)
        {
            await examRepository.InsertExamAsync(mapper.Map<Exam>(examdto));
            return Ok();
        }

        // PUT api/exams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PostExamDto examdto)
        {
            if (IdExists(id))
            {
                var exam = mapper.Map<Exam>(examdto);
                exam.Id = id;
                await examRepository.UpdateExamAsync(exam);
                return Ok();
            }
            else { return NoContent(); }
        }

        // DELETE api/exams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (IdExists(id))
            {
                await examRepository.DeleteExamAsync(id);
                return Ok();
            }
            else { return NoContent(); }
        }

        // GET api/exams/{id}/questions
        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetAllQuestionsByExamId(string id)
        {
            if (!IdExists(id)) return NoContent();
            var questions = await questionRepository.GetAllQuestionsByExamId(id);
            return Ok(questions);
        }

        // POST api/exams/{id}/questions
        [HttpPost("{id}/questions")]
        public async Task<IActionResult> AddExamQuestion(string id, [FromBody] PostQuestionDto questiondto)
        {
            if (!IdExists(id)) return NoContent();
            var exam = await examRepository.GetExamByIdAsync(id);
            exam.Questions.Add(mapper.Map<Question>(questiondto));
            await examRepository.InsertExamAsync(exam);
            return Ok();
        }
        // DELETE api/exams/{eid}/questions/{qid}
        [HttpDelete("{eid}/questions/{qid}")]
        public async Task<IActionResult> RemoveExamQuestion(string eid, string qid)
        {
            var exam = await examRepository.GetExamByIdAsync(eid);
            var question = await questionRepository.GetQuestionByIdAsync(qid);
            exam.Questions.Remove(question);
            await examRepository.UpdateExamAsync(exam);
            return Ok();
        }


        //Utilities
        protected bool IdExists(string id)
        {
            var exists = false;
            var exam = examRepository.GetExamByIdAsync(id);
            if (exam != null) {exists = true;}
            return exists;
        }
    }
}
