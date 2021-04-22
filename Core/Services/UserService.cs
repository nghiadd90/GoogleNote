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
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetById(int userId);

        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);
        void AddUser(User user);
    }

    public class UserService : IUserService
    {
        private DatabaseContext _ctx;

        public UserService(DatabaseContext context)
        {
            this._ctx = context;
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

        public User GetById(int userId)
        {
            return _ctx.Set<User>().Find(userId);
        }

        public void UpdateUser(int userId, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
