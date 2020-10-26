namespace DatingApp.Services.Jwt
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Models.Entities;
    using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

    public class TokenService : ITokenService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly SymmetricSecurityKey key;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public TokenService(IConfiguration configuration)
        {
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
            };

            var credentials = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenGenerated = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenGenerated);

        }
    }
}