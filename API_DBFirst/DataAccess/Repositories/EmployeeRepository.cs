using DataAccess.DataModel;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(API_DBFirstDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Employees>> GetAll()
        {
            return await Context.Employees.ToListAsync();
        }

        public async Task<Employees> GetById(int id)
        {
            return await Context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Employees empl)
        {
            Context.Employees.Add(empl);
            Context.SaveChanges();
        }
    }
}
