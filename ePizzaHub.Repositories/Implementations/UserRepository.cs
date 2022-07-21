using DAL;
using DAL.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        //ePizzaHubContext _db;
        DbContext _db;
        ePizzaHubContext context
        {
            get
            {
                return _db as ePizzaHubContext;
                
            }

        }
        public UserRepository(DbContext db) : base(db)
        {
            
        }

        public bool CreateUser(User user, string role)
        {
            try
            {
                user.Password = BC.HashPassword(user.Password);
                  Role role1 = context.Roles.Where(r => r.Name == role).FirstOrDefault();
                user.Roles.Add(role1);

                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public UserModel ValidateUser(string email, string password)
        {
            User user = context.Users.Include(u => u.Roles).Where(r => r.Email == email).FirstOrDefault();
            if (user != null)
            {
                bool isVerified = BC.Verify(password, user.Password);
                if (isVerified)
                {
                    UserModel model = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };
                    return model;
                }
                return null;

            }
            return null;
        }
    }
}
