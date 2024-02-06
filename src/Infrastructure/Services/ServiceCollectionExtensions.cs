using Cosmos.Abstracts;
using Infrastructure.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services) {

            if (services is null)
                throw new ArgumentNullException(nameof(services), "A service collection is required.");

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.Replace(ServiceDescriptor.Singleton<ICosmosFactory, LocalCosmosFactory>());
            }             

            return services;
        }
    }
}
