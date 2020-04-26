using AutoMapper;
using DataModel;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CodeFirst.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
