using APICoreSolution.Domain.Interfaces.Repositories;
using APICoreSolution.Infrastructure.Data.DAOs;
using APICoreSolution.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.CrossCutting.DependencyInjection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            // Infrastructure
            services.AddDbContext<ApplicationDbContext>();

            // Unit of Work
            services.AddScoped<IDbTransaction, DbTransaction>();

            //Services
            services.AddServices();

            //Repositories
            services.AddRepositories();

            //Data Object Access
            services.AddDataObjectAccess();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add your application services here

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add your application repositories here
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            return services;
        }
        public static IServiceCollection AddDataObjectAccess(this IServiceCollection services)
        {
            // Add your DAOs here
            services.AddScoped<UserDAO>();
            services.AddScoped<AuthDAO>();

            return services;
        }
    }
}
