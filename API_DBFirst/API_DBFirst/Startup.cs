using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_DBFirst.Errors;
using AutoMapper;
using BusinessAceess.IServices;
using BusinessAceess.Services;
using BusinessAceess.UnitOfWork;
using DataAccess.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API_DBFirst
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<API_DBFirstDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DotNet Core API With DBFirst",
                    Version = "v1",
                    Description = "DotNet Core 3.1 API With Entity Framework Database First Approach"
                });
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ExceptionMiddleware));
            // Static files aren't compressed by Static File Middleware.
            //app.UseStaticFiles();
            //app.UseResponseCompression();
            //app.UseCookiePolicy();
            app.UseRouting();
            // app.UseRequestLocalization();
            //Enabling CORS for Localhost usage
            app.UseCors(options => options.AllowAnyOrigin());

            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseSession();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
