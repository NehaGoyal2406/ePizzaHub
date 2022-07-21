using DAL;
using DAL.Entities;
using ePizzaHub.Repositories.Implementations;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Implementations;
using ePizzaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //db dependencies
            services.AddDbContext<ePizzaHubContext>(options =>
                                            {
                                                options.UseSqlServer(configuration.GetConnectionString("DBConnection"));

                                            });

            services.AddScoped<DbContext, ePizzaHubContext>();
            //other dependencies  

            //repository: generic
            services.AddScoped<IRepository<User>, Repository<User>>();
            //repository: generic
            services.AddScoped<IUserRepository, UserRepository>();

            //dependencies for services
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
