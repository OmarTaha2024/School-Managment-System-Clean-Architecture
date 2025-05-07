using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Infrustructure.InfrustructureBases;

namespace SchoolManagment.Infrustructure.Abstract
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
