using SchoolManagment.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(200)]
        [Required]
        public string NameAr { get; set; }
        [StringLength(200)]
        [Required]
        public string NameEn { get; set; }

        public string Address { get; set; }
        [StringLength(200)]
        public string phone { get; set; }
        public int? Did { get; set; }
        [ForeignKey("Did")]

        public virtual Department Department { get; set; }
    }
}
