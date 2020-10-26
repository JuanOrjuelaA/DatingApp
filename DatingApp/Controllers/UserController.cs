
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
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this.userService.GetUser(id);
            return this.Ok(user);
        }
    }

}