using System.Collections.Generic;

namespace ShoppingCartAPI.Repository.Contract
{
    public interface IUserRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int Id);
        User CreateUser(User product);
        User UpdateUser(User product);
        User DeleteUser(int Id);
    }
}
