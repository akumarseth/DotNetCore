using BusinessAceess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAceess.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeesViewModel>> GetAll();
        Task<EmployeesViewModel> GetById(int id);
        int Save(EmployeesViewModel employeesViewModel);
        bool Update(EmployeesViewModel employeesViewModel);
    }
}
