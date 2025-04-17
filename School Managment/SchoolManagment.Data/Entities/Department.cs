using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Data.Entities
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Departments = new HashSet<DepartmetSubject>();


        }
        [Key]
        public int Did { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> Departments { get; set; }

    }
}
