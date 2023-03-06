using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.PL.Models;

namespace TSReimbursementApp.PL.Mapper
{
    public class WebMappingProfile:Profile
    {
        public WebMappingProfile() : base("WebMappingProfile")
        {
            CreateMap<ReimbursementViewModel, ReimbursementDTO>().ReverseMap();
            CreateMap<SignupModel, SignupDTO>().ReverseMap();
            CreateMap<LoginViewModel,LoginDTO>().ReverseMap();
        }
    }
}
