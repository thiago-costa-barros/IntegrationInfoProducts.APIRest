using ExternalWebhookReceiverAPI.Application.Interfaces.Hotmart;
using ExternalWebhookReceiverAPI.Application.Services;
using ExternalWebhookReceiverAPI.Application.Services.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs;
using ExternalWebhookReceiverAPI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.CrossCutting.DependencyInjection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            // Infrastructure
            services.AddDbContext<ApplicationDbContext>();

            // Unit of Work
            //services.AddScoped<IDbTransaction, DbTransaction>();

            //Services
            services.AddServices();

            //Repositories
            services.AddRepositories();

            //Data Object Access
            services.AddDataObjectAccess();

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceApplication>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceInfrastructure>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddDataObjectAccess(this IServiceCollection services)
        {
            
        }
    }
}
