using CommonSolution.Domain.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories.Common
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<Person?> GetPersonByTaxNumberAsync(string taxNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> InsertPersonAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
