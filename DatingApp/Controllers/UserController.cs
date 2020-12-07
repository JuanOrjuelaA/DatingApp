
namespace DatingApp.Controllers
{
    using System.Threading.Tasks;
    using Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Users;

    public class UserController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserList()
        {
            var result = await this.userService.GetAvailableUsers();
            return this.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await this.userService.GetUserByName(userName);
            return this.Ok(user);
        }
    }

}