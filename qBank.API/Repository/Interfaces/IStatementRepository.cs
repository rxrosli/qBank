using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.API.Repository.Interfaces
{
    public interface IStatementRepository
    {
        Task<Statement> GetByStatementIdAsync(string id);
        Task InsertStatementAsync(Statement statement);
        Task UpdateStatementAsync(Statement statement);
        Task DeleteStatementAsync(string id);
    }
}
