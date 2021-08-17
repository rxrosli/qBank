using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.Models
{
    public class Question
    {
        public String QuestionID { get; set; }
        public String Statement { get; set; }
        public ICollection<String> Truths { get; set; }
        public ICollection<String> Faults { get; set; }
    }
}
