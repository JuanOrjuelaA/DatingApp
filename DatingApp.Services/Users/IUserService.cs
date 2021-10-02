namespace DatingApp.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.DTOs;
    using Models.Entities;

    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MemberDto>> GetAvailableUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<AppUser> GetUser(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<MemberDto> GetUserByName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AppUser> RegisterUser(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> UserExist(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        Task<LoginDto> LoginUser(LoginDto loginInfo);
    }
}