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
        private readonly SqliteContext context;

        public ExamRepository(SqliteContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Exam>> GetExamsAsync()
        {
            return await context.Exams.ToListAsync();
        }

        public async Task<Exam> GetExamByIdAsync(string examId)
        {
            return await context.Exams.FindAsync(examId);
        }

        public async Task InsertExamAsync(Exam exam)
        {
            var id = Guid.NewGuid();
            exam.ExamId = id.ToString();
            context.Exams.Add(exam);
            await context.SaveChangesAsync();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            context.Exams.Update(exam);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExamAsync(string examId)
        {
             Exam exam = await context.Exams.FindAsync(examId);
            context.Exams.Remove(exam);
            await context.SaveChangesAsync();
        }
    }
}
