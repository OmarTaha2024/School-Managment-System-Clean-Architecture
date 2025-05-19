using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Infrustructure.Abstract.Procedures;
using SchoolManagment.Infrustructure.Context;
using StoredProcedureEFCore;
namespace SchoolManagment.Infrustructure.Represatories.Procedures
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion
        #region Constructors
        public DepartmentStudentCountProcRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Handle Functions
        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameter parameters)
        {
            var rows = new List<DepartmentStudentCountProc>();
            await _context.LoadStoredProc(nameof(DepartmentStudentCountProc))
                   .AddParam(nameof(DepartmentStudentCountProcParameter.did), parameters.did)
                   .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());

            return rows;
        }
        #endregion

    }
}
