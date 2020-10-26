namespace DatingApp.Services.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;

    public class UserService : IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DatingDbContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserService(DatingDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> GetAvailableUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AppUser> GetUser(int userId)
        {
            var result = await this.context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AppUser> RegisterUser(string userName, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser()
            {
                UserName = userName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            await this.context.Users.AddAsync(user);

            await this.context.SaveChangesAsync();

            return user;
        }
    }
}