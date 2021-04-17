using System.Collections.Generic;
using GoogleNote.Core.Models;

namespace GoogleNote.Core.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int userId);

        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);
        void AddUser(User user);
    }
}