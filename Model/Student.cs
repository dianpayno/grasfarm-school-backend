using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Model
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = "";
        public string Gender { get; set; } = "";
        public string? Country { get; set; } = "";
        public long PhoneNumber { get; set; }
        public string Address { get; set; } = "";
        public int IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }



    }
}