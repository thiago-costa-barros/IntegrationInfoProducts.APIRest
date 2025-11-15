using CommonSolution.Domain.Entities.CoreSchema;

namespace ExternalWebhookReceiverAPI.Application.Interfaces.DAOs
{
    public interface IPersonDAO
    {
        Task<Person?> GetPersonByTaxNumberAsync(string taxNumber);
        Task<Person> InsertPersonAsync(Person person);
    }
}
