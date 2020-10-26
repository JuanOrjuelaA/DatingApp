
namespace DatingApp.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
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
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(string userName, string password)
        {
            var userCreated = await this.userService.RegisterUser(userName, password);
            return this.Ok(userCreated);
        }
    }
}
