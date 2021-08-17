using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qBank.Models;

namespace qBank.API.Repository.Interfaces
{
    public interface IExamRepository
    {
        Task<ICollection<Exam>> GetExamsAsync();
        Task<Exam> GetExamByIdAsync(string examId);
        Task InsertExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(string examId);
    }
}
