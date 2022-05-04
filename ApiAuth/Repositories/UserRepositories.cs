using ApiAuth.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiAuth.Repositories
{
    public class UserRepositories
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new() {Id = 1, Username = "batman", Password = "batman", Role = "manager"},
                new() {Id = 2, Username = "robin", Password = "robin", Role = "employee"},
            };
            return users
                .FirstOrDefault(x =>
                    x.Username == username
                && x.Password == password);

        }
    }
}
