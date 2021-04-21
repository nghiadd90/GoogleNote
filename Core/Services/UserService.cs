using System.Collections.Generic;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
using GoogleNote.Core.Models;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Linq;

namespace GoogleNote.Core.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext _ctx;

        public UserService(DatabaseContext context)
        {
            this._ctx = context;
        }


        public async Task<User> Login(string email, string password)
        {
            var user =  _ctx.Set<User>().Single(u => u.Email == email);
            var userPwd = user.Password;
            return user;
        }

        public async Task<User> Register(User user, string pwd)
        {
            user.Password = BC.HashPassword(pwd);

            await _ctx.Users.AddAsync(user); // Adding the user to context of users.
            await _ctx.SaveChangesAsync(); // Save changes to database.

            return user;
        }

        private string GenerateJwtToken(User user)
        {
            return "";
        }

        private bool VerifyPassword(string curPwd, string pwd)
        {
            return true;
        }

        public void AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(int userId, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
