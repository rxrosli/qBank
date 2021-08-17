using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.Models
{
    public class Exam
    {
        public string ExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
