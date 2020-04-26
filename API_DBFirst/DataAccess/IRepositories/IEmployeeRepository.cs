using DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        Task<List<Employees>> GetAll();
        Task<Employees> GetById(int id);
        void Save(Employees employees);
    }
}
