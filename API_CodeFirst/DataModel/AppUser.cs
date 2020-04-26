using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel
{
    public class AppUser:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long MobileNo { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsLocked { get; set; }
    }
}
