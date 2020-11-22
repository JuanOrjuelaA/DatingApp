namespace DatingApp.Infrastructure.Repositories.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Entities;

    public interface IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void Update(AppUser user);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AppUser>> GetUsersAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppUser> GetUserByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<AppUser> GetUserByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUserAsync(AppUser user);

    }
}