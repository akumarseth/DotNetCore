using System;
using System.Collections.Generic;

namespace DataAccess.DataModel
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; }
    }
}
