using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }

    }
}
