using CommonSolution.Entities.CoreSchema;
using CommonSolution.Resources;
using ExternalWebhookReceiverAPI.Application.Interfaces.Repositories;
using ExternalWebhookReceiverAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace ExternalWebhookReceiverAPI.Application.Services.Common
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _businessUnitRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public BusinessUnitService(IBusinessUnitRepository businessUnitRepository, IHttpContextAccessor httpContextAccessor)
        {
            _businessUnitRepository = businessUnitRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId)
        {
            BusinessUnit? businessUnit = await _businessUnitRepository.GetBusinessUnitById(businessUnitId);
            if (businessUnit == null)
                throw new UnauthorizedAccessException(ExceptionMessages.EXC0002);

            _httpContextAccessor.HttpContext?.Items.TryAdd("CompanyId", businessUnit.CompanyId);
            _httpContextAccessor.HttpContext?.Items.TryAdd("BusinessUnitId", businessUnit.BusinessUnitId);

            return businessUnit;
        }
    }
}
