using AutoMapper;

namespace SchoolManagment.Core.Mapping.Instructors
{
    public partial class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            AddInstructorMapping();
        }
    }
}
