namespace DatingApp.Services.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using Models.DTOs;
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
                UserName = userName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            await this.context.Users.AddAsync(user);

            await this.context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> UserExist(string userName)
        {
            return await this.context.Users.AnyAsync(x => x.UserName.Equals(userName.ToLower()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public async Task<LoginDto> LoginUser(LoginDto loginInfo)
        {
            loginInfo.LoginWasSuccessful = true;
            var userSelected = await this.context.Users
                .SingleOrDefaultAsync(x => x.UserName.Equals(loginInfo.UserName.ToLower()));

            if (userSelected == null)
            {
                loginInfo.LoginWasSuccessful = false;
                loginInfo.Message = "Invalid User name";
                return loginInfo;
            }

            using var hmac = new HMACSHA512(userSelected.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginInfo.Password));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userSelected.PasswordHash[i])
                {
                    loginInfo.LoginWasSuccessful = false;
                    loginInfo.Message = "Invalid password";
                }
            }

            return loginInfo;
        }
    }
}