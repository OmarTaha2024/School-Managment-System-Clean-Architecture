using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Context;
using SchoolManagment.Infrustructure.InfrustructureBases;

namespace SchoolManagment.Infrustructure.Represatories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        protected readonly DbSet<UserRefreshToken> _userrefreshToken;

        #endregion
        #region Ctor

        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userrefreshToken = dbContext.Set<UserRefreshToken>();

        }
        #endregion
        #region Handle Function


        #endregion
    }
}
