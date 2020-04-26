using ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccess.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetEmployeeById(Guid id);
        EmployeeViewModel CreateEmployee(EmployeeViewModel viewModel);
        void UpdateEmployee(EmployeeViewModel viewModel);
        void DeleteEmployee(Guid id);
    }
}
