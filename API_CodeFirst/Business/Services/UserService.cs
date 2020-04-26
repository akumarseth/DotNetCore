using AutoMapper;
using BusinessAccess.IServices;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BusinessAccess.Services
{
    public class UserService:IUserService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public bool IsValidUser(LoginViewModel user)
        {
            // need to config in UOW with  repository 
            return true;
        }
    }
}
