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
        Task<Question> GetQuestionByIdAsync(string questionId);
        Task InsertQuestionAsync(Question questionId);
        Task UpdateQuestionAsync(Question questionId);
        Task DeleteQuestionAsync(string questionId);
    }
}
