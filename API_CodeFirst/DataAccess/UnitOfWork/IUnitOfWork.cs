using DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        void Commit();
        void Rollback();
    }
}
