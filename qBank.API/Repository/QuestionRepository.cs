using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qBank.API.Repository.Interfaces;
using qBank.Data.SQLite;
using qBank.Models;

namespace qBank.API.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SqliteContext context;

        public QuestionRepository(SqliteContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Question>> GetQuestionsAsync()
        {
            return await context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(string id)
        {
            return await context.Questions.FindAsync(id);
        }

        public async Task InsertQuestionAsync(Question question)
        {
            question.Id = Guid.NewGuid().ToString();
            context.Questions.Add(question);
            await context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            context.Questions.Update(question);
            await context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(string id)
        {
            Question question = await context.Questions.FindAsync(id);
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllQuestionsByExamId(string id)
        {
            var exam = await context.Exams.FirstAsync(exam => exam.Id == id);
            var examQuestionIds = exam.Questions.Aggregate(new List<string>(), (ids, examQuestion) => {
                ids.Add(examQuestion.Id);
                return ids;
            });
            
            return context.Questions.Where(question => examQuestionIds.Contains(question.Id)).ToList();
        }
    }
}
