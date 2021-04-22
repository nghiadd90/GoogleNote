using System;
using System.Linq;
using System.Threading.Tasks;
using GoogleNote.Core.Models;
using System.Security.Claims;
using GoogleNote.Core.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace GoogleNote.Core.Services
{
    public interface IAuthService
    {
        LoginResult Login(string email, string password);
        Task<User> Register(string email, string password);
    }

    public class AuthService : IAuthService
    {
        private DatabaseContext _ctx;
        // private AppSettings _appSettings;

        public AuthService(DatabaseContext context /*, IOptions<AppSettings> appSettings*/)
        {
            _ctx = context;
            // _appSettings = appSettings.Value;
        }


        public LoginResult Login(string email, string password)
        {
            var user =  _ctx.Users.FirstOrDefault(u => u.Email == email);
            
            if (user == null) {
                return null;
            }

            if (!PasswordHasher.VerifyPassword(user, password)) {
                return null;
            }

            var token = GenerateJwtToken(user);

            return new LoginResult(user, token);
        }

        public async Task<User> Register(string email, string password)
        {
            byte[] salt = PasswordHasher.SaltGenerator();

            User user = new User();
            user.Email = email;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.Password = PasswordHasher.HashPassword(password, salt);

            await _ctx.Users.AddAsync(user);            
            await _ctx.SaveChangesAsync();

            return user;
        }

        private string GenerateJwtToken(User user)
        {
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(/*_appSettings.Secret*/"ijurkbdlhmklqacwqzdxmkkhvqowlyqa");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public int? ValidateJwtToken(string token)
{
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return account id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
