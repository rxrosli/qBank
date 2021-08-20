using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.API.DTO
{
    public class GetExamsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class PostExamDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
