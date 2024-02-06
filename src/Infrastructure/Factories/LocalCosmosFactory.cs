using Cosmos.Abstracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Factories
{
    internal class LocalCosmosFactory : CosmosFactory
    {
        public LocalCosmosFactory(ILogger<CosmosFactory> logger, IOptions<CosmosRepositoryOptions> repositoryOptions, IHttpClientFactory httpClientFactory) : base(logger, repositoryOptions, httpClientFactory)
        {
        }

        protected override CosmosClientOptions ClientOptions()
        {
            var localOptions = base.ClientOptions();

            localOptions.HttpClientFactory = () =>
            {
                HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
                return new HttpClient(httpMessageHandler);
            };
            localOptions.ConnectionMode = ConnectionMode.Gateway;

            return localOptions;
        }
    }
}
