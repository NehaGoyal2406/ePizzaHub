using DAL.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implementations
{
    public class AuthService : IAuthService
    {
        IUserRepository _userRepo;
        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;

        }
        public bool CreateUser(User user, string role)
        {
           return  _userRepo.CreateUser(user,role);
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            return _userRepo.ValidateUser(Email, Password);
        }
    }
}
