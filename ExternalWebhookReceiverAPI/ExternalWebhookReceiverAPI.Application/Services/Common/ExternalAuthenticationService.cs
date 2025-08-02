using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Common;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    internal class ExternalAuthenticationService : IExternalAuthenticationService
    {
        public Task<Company?> GetCompanyFromTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
