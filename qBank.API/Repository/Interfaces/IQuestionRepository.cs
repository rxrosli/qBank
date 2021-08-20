using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qBank.Models;

namespace qBank.API.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Task<ICollection<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(string id);
        Task InsertQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(string id);
        Task<List<Question>> GetAllQuestionsByExamId(string id);
    }
}
