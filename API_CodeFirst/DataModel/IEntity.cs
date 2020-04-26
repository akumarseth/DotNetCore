using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
