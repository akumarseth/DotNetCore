using AutoMapper;
using BusinessAceess.Entities;
using BusinessAceess.IServices;
using BusinessAceess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataModel;

namespace BusinessAceess.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<EmployeesViewModel>> GetAll()
        {
            try
            {
                var dbEntities = await _uow.EmployeesRepository.GetAll();
                var employeesEntities = _mapper.Map<List<EmployeesViewModel>>(dbEntities);
                return employeesEntities;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<EmployeesViewModel> GetById(int id)
        {
            try
            {
                var dbEntity = await _uow.EmployeesRepository.GetById(id);
                var employeesEntities = _mapper.Map<EmployeesViewModel>(dbEntity);
                return employeesEntities;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int Save(EmployeesViewModel employeesViewModel)
        {
            try
            {
                var dbentities = _mapper.Map<Employees>(employeesViewModel);
                _uow.EmployeesRepository.Save(dbentities);
                return dbentities.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(EmployeesViewModel employeesViewModel)
        {
            bool isUpdated = false;
            try
            {
                if (employeesViewModel != null)
                {
                    var employee = _uow.EmployeesRepository.FirstOrDefault(x => x.Id == employeesViewModel.Id);
                    if (employee != null)
                    {
                        var dbentities = _mapper.Map(employeesViewModel, employee);
                        _uow.Save();
                        isUpdated = true;
                    }
                }

                return isUpdated;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
