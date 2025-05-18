using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Commons;

namespace SchoolManagment.Data.Entities.Views
{
    [Keyless]
    public class ViewDepartment : GeneralLocalizableEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int Student_count { get; set; }
    }
}
