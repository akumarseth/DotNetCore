using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAceess.Entities;
using BusinessAceess.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _employee.GetAll();
            if (output == null)
            {
                return NotFound();
            }

            return Ok(output);
         }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var output = await _employee.GetById(id);
            if (output == null)
            {
                return NotFound();
            }
            return Ok(output);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeesViewModel employeeViewModel)
        {
            var output = _employee.Save(employeeViewModel);
            if (output == 0)
            {
                return BadRequest();
            }
            return Ok(output);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, EmployeesViewModel employeeViewModel)
        {
            if(id != employeeViewModel.Id)
            {
                return BadRequest("Id mismatch");
            }
            var isUpdated = _employee.Update(employeeViewModel);
            if (isUpdated)
            {
                return Ok(isUpdated);
            }
            else
            {
                return BadRequest(isUpdated);
            }
        }
    }
}