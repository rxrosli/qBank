using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace qBank.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string Query { get; set; }
        public List<Statement> Statements { get; set; }

        [JsonIgnore]
        public List<Exam> Exams { get; set; }
    }

    public class Statement
    {
        public string Id { get; set; }
        public bool IsTrue { get; set; }
        public string Value { get; set; }
    }
}
