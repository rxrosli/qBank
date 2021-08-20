using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.API.DTO
{
    public class PostQuestionDto
    {
        public string Query { get; set; }
        public List<PostStatementDto> Statements { get; set; }
    }

    public class PostStatementDto
    {
        public bool IsTrue { get; set; }
        public string Value { get; set; }
    }
}
