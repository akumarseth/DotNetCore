using DataAccess.IRepositories;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        private IEmployeeRepository _employeeRepository;
        //private IRepository<Book> _bookRepository;
        public UnitOfWork(ApplicationDBContext databaseContext)
        { 
            _dbContext = databaseContext; 
        }

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_dbContext); }
        }

        //public IRepository<Book> BookRepository
        //{
        //    get { return _bookRepository = _bookRepository ?? new Repository<Book>(_databaseContext); }
        //}

        public void Commit()
        { 
            _dbContext.SaveChanges(); 
        }

        public void Rollback()
        { 
            _dbContext.Dispose(); 
        }
    }
}
