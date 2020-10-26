
namespace DatingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Base;
    using Models.DTOs;
    using Models.Entities;
    using Services.Jwt;
    using Services.Users;

    public class AccountController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ITokenService tokenService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="tokenService"></param>
        public AccountController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            if (await this.userService.UserExist(registerDto.UserName))
            {
                return this.BadRequest("User name had already taken");
            }

            var userCreated = await this.userService.RegisterUser(
                registerDto.UserName, 
                registerDto.Password);

            
            return this.Ok(new UserDto()
            {
                UserName = userCreated.UserName,
                Token = this.tokenService.CreateToken(userCreated),
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto registerDto)
        {
            var user = await this.userService.LoginUser(registerDto);

            if (!user.LoginWasSuccessful)
            {
                return this.Unauthorized(user.Message);
            }

            return this.Ok(new UserDto()
            {
                UserName = user.UserName,
                Token = this.tokenService.CreateToken(new AppUser()
                {
                    UserName = user.UserName,
                    PasswordSalt = user.PasswordSalt,
                    PasswordHash = user.PasswordHash,
                }),
            });
        }
    }
}
