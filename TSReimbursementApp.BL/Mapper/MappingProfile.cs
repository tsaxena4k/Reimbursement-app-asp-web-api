using AutoMapper;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.DTOs;

namespace TSReimbursementApp.DAL.Mapper
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<ReimbursementDTO, ReimbursementDomain>().ReverseMap();
            CreateMap<SignupDTO, SignupDomain>().ReverseMap();
            CreateMap<LoginDTO, LoginDomain>().ReverseMap();
        }
    }
}
