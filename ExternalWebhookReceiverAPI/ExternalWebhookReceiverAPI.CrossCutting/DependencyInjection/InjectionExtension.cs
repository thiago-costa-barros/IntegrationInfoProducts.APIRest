using ExternalWebhookReceiverAPI.Application.Services;
using ExternalWebhookReceiverAPI.Infrastructure;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
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

            //Validators
            services.AddValidators();

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
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceInfrastructure>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("DAO")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceApplication>() 
                .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
