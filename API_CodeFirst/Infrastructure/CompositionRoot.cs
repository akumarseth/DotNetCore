using BusinessAccess.IServices;
using BusinessAccess.Services;
using DataAccess;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ViewModel;

namespace Infrastructure
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
        }

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ApplicationDBContext>();

            services.AddTransient<IUserService, UserService>();
            services.Configure<AuthOptionsViewModel>(configuration.GetSection("AuthOptions"));
            
            AuthProvider.CreateToken(services, configuration);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
