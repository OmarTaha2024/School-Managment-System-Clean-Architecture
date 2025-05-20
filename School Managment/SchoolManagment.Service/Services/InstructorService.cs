using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Abstract.Functions;
using SchoolManagment.Infrustructure.Context;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    public class InstructorService : IInstructorService
    {
        #region Fileds
        private readonly ApplicationDbContext _dbContext;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        private readonly IInstructorsRepository _instructorsRepository;
        #endregion
        #region Constructors
        public InstructorService(ApplicationDbContext dbContext,
                                 IInstructorFunctionsRepository instructorFunctionsRepository,
                                 IInstructorsRepository instructorsRepository)
        {
            _dbContext = dbContext;
            _instructorFunctionsRepository = instructorFunctionsRepository;
            _instructorsRepository = instructorsRepository;

        }

        public Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            result = _instructorFunctionsRepository.GetSalarySummationOfInstructorFunc("select dbo.GetSalarySummition()");
            return Task.FromResult(result);
        }



        #endregion
    }
}
