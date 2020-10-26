﻿namespace DatingApp.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}