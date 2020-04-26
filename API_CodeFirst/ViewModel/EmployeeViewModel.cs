using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; }
    }
}
