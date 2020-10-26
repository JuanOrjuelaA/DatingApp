namespace DatingApp.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDto
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

        /// <summary>
        /// 
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LoginWasSuccessful { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }
}