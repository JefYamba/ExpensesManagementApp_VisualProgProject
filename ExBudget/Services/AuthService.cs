using ExBudget.Models;
using ExBudget.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Services
{
    public class AuthService
    {
        private readonly UserRepository userRepo = new UserRepository();
        public static User currentUser = null;
        public bool Login(string username, string password)
        {
            User user = userRepo.FindByUsernameAndPassword(username, password);
            if (user != null) {
                currentUser = new User() 
                { 
                    Id = user.Id,
                    Username = string.Empty,
                    Password = string.Empty,
                    DisplayName = user.DisplayName,
                };
            }
            return user != null;
        }
        
    }
}
