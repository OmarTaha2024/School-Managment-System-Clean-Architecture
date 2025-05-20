namespace SchoolManagment.Service.Abstracts
{
    public interface IInstructorService
    {
        public Task<decimal> GetSalarySummationOfInstructor();
    }
}
