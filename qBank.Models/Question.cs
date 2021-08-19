using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Statement { get; set; }
        public List<Truth> Truths { get; set; }
        public List<Fault> Faults { get; set; }
    }

    public class Truth
    {
        public string TruthId { get; set; }
        public string Value { get; set; }
    }

    public class Fault
    {
        public string FaultId { get; set; }
        public string Value { get; set; }
    }
}
