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
    public class ExamRepository : IExamRepository
    {
        private readonly SqliteContext _context;

        public ExamRepository(SqliteContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Exam>> GetExamsAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam> GetExamByIdAsync(string examId)
        {
            return await _context.Exams.FindAsync(examId);
        }

        public async Task InsertExamAsync(Exam exam)
        {
            var id = Guid.NewGuid();
            exam.ExamId = id.ToString();
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExamAsync(string examId)
        {
             Exam exam = await _context.Exams.FindAsync(examId);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }
    }
}
