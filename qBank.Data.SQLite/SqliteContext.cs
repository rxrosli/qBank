using Microsoft.EntityFrameworkCore;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.Data.SQLite
{
    public class SqliteContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public string DbPath { get; private set; }

        public SqliteContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}qBank.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
