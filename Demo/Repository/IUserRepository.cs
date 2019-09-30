using Demo.Models;
using Demo.Pocos;
using System.Collections.Generic;

namespace Demo.Repository
{
    public interface IUserRepository
    {
        User GetUser(int? id);
        List<User> GetUsers();
        int AddUser(UserPocos user);
        void UpdateUser(UserPocos user);
        void DeleteUser(int id);

    }
}