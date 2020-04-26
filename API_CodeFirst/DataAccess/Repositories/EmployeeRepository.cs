using DataModel;
using DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext context) : base(context) { }

        //public Task<List<Employee>> GetAll()
        //{
        //    return context.Employees.
        //}
    }
}
