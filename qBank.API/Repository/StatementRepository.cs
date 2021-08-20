using qBank.API.Repository.Interfaces;
using qBank.Data.SQLite;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.API.Repository
{
    public class StatementRepository : IStatementRepository
    {
        private readonly SqliteContext context;

        public StatementRepository(SqliteContext context)
        {
            this.context = context;
        }

        public async Task<Statement> GetByStatementIdAsync(string id)
        {
            return await context.Statements.FindAsync(id);
        }

        public async Task InsertStatementAsync(Statement statement)
        {
            statement.Id = Guid.NewGuid().ToString();
            context.Statements.Add(statement);
            await context.SaveChangesAsync();
        }

        public async Task UpdateStatementAsync(Statement statement)
        {
            context.Statements.Update(statement);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStatementAsync(string id)
        {
            Statement statement = await context.Statements.FindAsync(id);
            context.Statements.Remove(statement);
            await context.SaveChangesAsync();
        }
    }
}
