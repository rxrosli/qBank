using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.Models
{
    public class Exam
    {
        public String ExamId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
