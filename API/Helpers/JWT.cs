using API.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Helpers
{
    public static class JWT
    {
        private static readonly string _secretKey = "kF7uPz@!aTc9@3dLo9k8Q2w#FvH3Ym6wzj98XzX4GpW1J*mNrLs2KhcUbP5R9Wqz";
        private static readonly string _issuer = "JWTAuthenticationServer";
        private static readonly string _audience = "JWTServicePostmanClient";
        private static readonly string _subject = "JWTServiceAccessToken";

        public static string GenerateJwtToken(string Id, string username, string Email, IConfiguration configuration)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim("Id",Id),
                new Claim("UserName",username),
                new Claim("Email", Email),
                new Claim(JwtRegisteredClaimNames.Jti, IdGenerator.GenerateUniqueId())

                //new Claim(JwtRegisteredClaimNames.Sub, _subject),
                //new Claim(ClaimTypes.NameIdentifier,Id),
                //new Claim(ClaimTypes.Name,username),
                //new Claim(ClaimTypes.Email, Email),
                //new Claim(JwtRegisteredClaimNames.Jti, IdGenerator.GenerateUniqueId())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
