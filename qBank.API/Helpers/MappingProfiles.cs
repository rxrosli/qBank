using AutoMapper;
using qBank.API.DTO;
using qBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qBank.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostQuestionDto, Question>();
            CreateMap<PostStatementDto, Statement>();
            
            CreateMap<Exam, GetExamsDto>();
            CreateMap<PostExamDto, Exam>();

        }
    }
}
