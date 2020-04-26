using System;
using System.Collections.Generic;

namespace BusinessAceess.Entities
{
    public partial class EmployeesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; }
    }
}
