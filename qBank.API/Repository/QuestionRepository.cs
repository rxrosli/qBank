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
        private readonly SqliteContext _context;

        public QuestionRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(string questionId)
        {
            return await _context.Questions.FindAsync(questionId);
        }

        public async Task InsertQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(string questionId)
        {
            Question question = await _context.Questions.FindAsync(questionId);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
