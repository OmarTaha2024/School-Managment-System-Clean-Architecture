using SchoolManagment.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Data.Entities
{
    public class Department : GeneralLocalizableEntity
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
        public string NameAr { get; set; }
        [StringLength(200)]
        [Required]
        public string NameEn { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> Departments { get; set; }

    }
}
