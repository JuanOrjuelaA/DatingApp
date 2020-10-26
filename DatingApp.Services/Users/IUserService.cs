namespace DatingApp.Services.Users
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Entities;

    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AppUser>> GetAvailableUsers();

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
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AppUser> RegisterUser(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> UserExist(string userName);
    }
}