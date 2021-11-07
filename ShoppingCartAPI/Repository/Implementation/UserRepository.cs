using ShoppingCartAPI.Context;
using ShoppingCartAPI.Entities;
using ShoppingCartAPI.Repository.Contract;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartAPI.Repository.Implementation
{
    public class UserRepository : IUserRepository<User>
    {
        readonly ShoppingCartContext _shoppingCartContext;
        public UserRepository(ShoppingCartContext context)
        {
            _shoppingCartContext = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _shoppingCartContext.Users.ToList();
        }

        public User GetUser(int Id)
        {
            return _shoppingCartContext.Users.FirstOrDefault(x => x.Id == Id);
        }

        public User CreateUser(User user)
        {
            _shoppingCartContext.Users.Add(user);
            _shoppingCartContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            var oldUser = _shoppingCartContext.Users.FirstOrDefault(s => s.Id == user.Id);
            if (oldUser != null)
            {
                _shoppingCartContext.Entry<User>(oldUser).CurrentValues.SetValues(user);
                _shoppingCartContext.SaveChanges();
            }
            return user;
        }

        public User DeleteUser(int Id)
        {
            var user = _shoppingCartContext.Users.FirstOrDefault(s => s.Id == Id);
            if (user != null)
            {
                _shoppingCartContext.Users.Remove(user);
                _shoppingCartContext.SaveChanges();
            }
            return user;
        }
    }
}
