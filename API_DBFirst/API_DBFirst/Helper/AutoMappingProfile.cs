using AutoMapper;
using BusinessAceess.Entities;
using DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DBFirst.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<EmployeesViewModel, Employees>().ReverseMap();
        }
    }
}
