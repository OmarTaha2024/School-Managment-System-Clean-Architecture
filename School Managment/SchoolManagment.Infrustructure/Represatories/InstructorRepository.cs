using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Context;
using SchoolManagment.Infrustructure.InfrustructureBases;

namespace SchoolManagment.Infrustructure.Represatories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {

        #region Fields
        protected readonly DbSet<Instructor> _istructor;

        #endregion
        #region Ctor

        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _istructor = dbContext.Set<Instructor>();
        }
        #endregion
        #region Handle Function
        #endregion
    }
}
