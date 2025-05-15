using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolManagment.Data.Entities.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string FullName { get; set; }
        public string? Address { get; set; }
        [EncryptColumn]
        public string? code { get; set; }
        public string? Country { get; set; }
        [InverseProperty(nameof(UserRefreshToken.user))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
