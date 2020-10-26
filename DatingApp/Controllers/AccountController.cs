
namespace DatingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Base;
    using Models.DTOs;
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
        /// <param name="userService"></param>
        public AccountController(IUserService userService)
        {
            this.userService = userService;
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

            return this.Ok(userCreated);
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

            return this.Ok(user);
        }
    }
}
