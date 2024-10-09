using AutoMapper;
using RiskAnalysis.Application;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Profiles
{
    public class JobSubjectProfile : Profile
    {
        public JobSubjectProfile()
        {
            CreateMap<JobSubjectRequest, JobSubjectDto>();
        }
    }
}
