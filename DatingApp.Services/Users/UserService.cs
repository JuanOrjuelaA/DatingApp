namespace DatingApp.Services.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure.Repositories.Users;
    using Models.DTOs;
    using Models.Entities;

    public class UserService : IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> GetAvailableUsers()
        {
            return await this.userRepository.GetUsersAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AppUser> GetUser(int userId)
        {
            var result = await this.userRepository.GetUserByIdAsync(userId);

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

            await this.userRepository.AddUserAsync(user);

            await this.userRepository.SaveAllAsync();

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> UserExist(string userName)
        {
            return await this.userRepository.GetUserByUserName(userName) != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public async Task<LoginDto> LoginUser(LoginDto loginInfo)
        {
            loginInfo.LoginWasSuccessful = true;
            var userSelected = await this.userRepository.GetUserByUserName(loginInfo.UserName.ToLower());

            if (userSelected == null)
            {
                loginInfo.LoginWasSuccessful = false;
                loginInfo.Message = "Invalid User name";
                return loginInfo;
            }

            using var hmac = new HMACSHA512(userSelected.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginInfo.Password));

            if (computedHash.Where((t, i) => t != userSelected.PasswordHash[i]).Any())
            {
                loginInfo.LoginWasSuccessful = false;
                loginInfo.Message = "Invalid password";
                return loginInfo;
            }

            loginInfo.PasswordHash = userSelected.PasswordHash;
            loginInfo.PasswordSalt = userSelected.PasswordSalt;

            return loginInfo;
        }
    }
}