using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApi.Model
{
    public class School
    {
        [Key]
        public Guid SchoolId { get; set; } = Guid.NewGuid();
        public string SchoolName { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = "";
        public string Website { get; set; } = "";
        public int IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}