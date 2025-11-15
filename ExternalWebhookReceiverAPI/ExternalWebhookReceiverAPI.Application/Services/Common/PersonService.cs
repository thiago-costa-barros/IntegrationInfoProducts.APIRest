using CommonSolution.Domain.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    public class PersonService : IPersonService
    {
        public async Task<Person> GetOrCreatePersonByTaxNumberAsync(string taxNumber)
        {
            throw new NotImplementedException();
        }
    }
}
