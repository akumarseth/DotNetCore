using AutoMapper;
using BusinessAccess.IServices;
using DataAccess.UnitOfWork;
using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BusinessAccess.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            var dbEntity =  _uow.EmployeeRepository.GetAll();
            var allEmp = _mapper.Map<List<EmployeeViewModel>>(dbEntity);
            return allEmp;
        }

        public EmployeeViewModel GetEmployeeById(Guid id)
        {
            var dbEntity = _uow.EmployeeRepository.GetById(id);
            var emp = _mapper.Map<EmployeeViewModel>(dbEntity);
            return emp;
        }

        public EmployeeViewModel CreateEmployee(EmployeeViewModel viewModel)
        {
            var emp = _mapper.Map<Employee>(viewModel);
            _uow.EmployeeRepository.Insert(emp);
            _uow.Commit();
            viewModel.Id = emp.Id;
            return viewModel;
        }

        public void UpdateEmployee(EmployeeViewModel viewModel)
        {
            var emp = _mapper.Map<Employee>(viewModel);
            _uow.EmployeeRepository.Update(emp);
            _uow.Commit();
            return;
        }

        public void DeleteEmployee(Guid id)
        {
            _uow.EmployeeRepository.Delete(id);
            _uow.Commit();
        }
    }
}
