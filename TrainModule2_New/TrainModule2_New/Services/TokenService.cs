using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace TrainModule2_New.Services
{
    public class TokenService
    {
        private readonly string _secretKey;
        private readonly int _expiryDuration;

        public TokenService(string secretKey, int expiryDuration)
        {
            _secretKey = secretKey;
            _expiryDuration = expiryDuration;
        }
        public string GenerateToken(string username, string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };
            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var cred =new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddMinutes(_expiryDuration)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
