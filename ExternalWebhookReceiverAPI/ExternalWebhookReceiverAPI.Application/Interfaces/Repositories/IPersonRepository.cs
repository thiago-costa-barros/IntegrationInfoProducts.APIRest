using CommonSolution.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<Person?> GetPersonByTaxNumberAsync(string taxNumber);
        Task<Person> InsertPersonAsync(Person person);
    }
}
