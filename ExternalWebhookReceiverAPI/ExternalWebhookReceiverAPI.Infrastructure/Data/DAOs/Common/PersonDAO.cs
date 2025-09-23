using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.Interfaces.DAOs;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs.Common
{
    public class PersonDAO : IPersonDAO
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
