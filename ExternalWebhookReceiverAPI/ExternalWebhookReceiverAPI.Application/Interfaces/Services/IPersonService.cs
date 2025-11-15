using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Person> GetOrCreatePersonByTaxNumberAsync(string taxNumber);
    }
}
