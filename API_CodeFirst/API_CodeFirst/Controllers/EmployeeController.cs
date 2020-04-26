using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccess.IServices;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel;

namespace API_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private IEmployeeService _service;


        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _service = employeeService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllEmployee()
        {
            return Ok(_service.GetAllEmployee());
        }

        /// <summary>
        /// This method is use to get the Emplye by id
        /// </summary>
        /// <param name="id">Unique idetifier for employee</param>
        /// <returns>Employe object filterd by provided iD</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            return Ok(_service.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] EmployeeViewModel employee)
        {
            _service.CreateEmployee(employee);
            _logger.LogInformation("Add Employee for EmployeeId: {EmployeeId}", employee.Id);

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult Put(Guid id, [FromBody] EmployeeViewModel employeeViewModel)
        {
            if(id != employeeViewModel.Id)
            {
                return BadRequest("Id Mismatch");
            }
            _service.UpdateEmployee(employeeViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public void Delete(Guid id) => _service.DeleteEmployee(id);

    }
}