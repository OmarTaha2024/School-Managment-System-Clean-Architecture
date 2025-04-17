using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(200)]
        public string phone { get; set; }
        public int? Did { get; set; }
        [ForeignKey("Did")]

        public virtual Department Department { get; set; }
    }
}
