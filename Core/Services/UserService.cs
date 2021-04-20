using System.Collections.Generic;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
using GoogleNote.Core.Models;

namespace GoogleNote.Core.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext _ctx;

        public UserService(DatabaseContext context)
        {
            this._ctx = context;
        }


        public async Task<User> Login(string userName, string email)
        {
            var user =  _ctx.Set<User>().Find(1);
            return user;
        }

        public async Task<User> Register(User user, string pwd)
        {
            user.Password = BC.HashPassword(pwd);

            await _ctx.Users.AddAsync(user); // Adding the user to context of users.
            await _ctx.SaveChangesAsync(); // Save changes to database.

            return user;
        }

        private string generateJwtToken(User user)
        {
            return "";
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
