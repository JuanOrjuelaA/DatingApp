namespace DatingApp.Services.Jwt
{
    using System.Threading.Tasks;
    using Models.Entities;

    public interface ITokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string CreateToken(AppUser user);
    }
}