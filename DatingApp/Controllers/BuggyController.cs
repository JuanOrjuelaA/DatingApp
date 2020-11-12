
using System;

namespace DatingApp.Controllers
{
    using Models.Entities;
    using Services.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Base;

    public class BuggyController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// 
        /// </summary>
        public BuggyController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret test";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var user =  this.userService.GetUser(-1).Result;

            if (user == null)
            {
                return this.NotFound();
            }
            
            return this.Ok(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var user =  this.userService.GetUser(-1).Result;

            return user.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return this.BadRequest("This was not a good request");
        }

    }
}
