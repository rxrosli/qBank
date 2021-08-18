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

        public async Task<Question> GetQuestionByIdAsync(string questionId)
        {
            return await context.Questions.FindAsync(questionId);
        }

        public async Task InsertQuestionAsync(Question question)
        {
            question.QuestionId = Guid.NewGuid().ToString();
            context.Questions.Add(question);
            await context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            context.Questions.Update(question);
            await context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(string questionId)
        {
            Question question = await context.Questions.FindAsync(questionId);
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllQuestionsByExamId(string examId)
        {
            var exam = await context.Exams.FirstAsync(exam => exam.ExamId == examId);
            var examQuestionIds = exam.Questions.Aggregate(new List<string>(), (ids, examQuestion) => {
                ids.Add(examQuestion.QuestionId);
                return ids;
            });
            
            return context.Questions.Where(question => examQuestionIds.Contains(question.QuestionId)).ToList();
        }
    }
}
