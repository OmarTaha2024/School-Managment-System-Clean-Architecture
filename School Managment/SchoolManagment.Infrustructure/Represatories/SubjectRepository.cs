using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Data;
using SchoolManagment.Infrustructure.InfrustructureBases;

namespace SchoolManagment.Infrustructure.Represatories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        protected readonly DbSet<Subjects> _subjects;

        #endregion
        #region Ctor

        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subjects = dbContext.Set<Subjects>();
        }
        #endregion
        #region Handle Function
        #endregion
    }
}
