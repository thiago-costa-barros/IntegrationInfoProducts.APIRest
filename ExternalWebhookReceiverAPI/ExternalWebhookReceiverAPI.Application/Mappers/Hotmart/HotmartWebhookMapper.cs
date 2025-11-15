using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using System.Text.Json;
using CommonSolution.Domain.Entities.Common;
using CommonSolution.Domain.Entities.CoreSchema;
using CommonSolution.Domain.Entities.IntegrationSchema;
using CommonSolution.Domain.Entities.Common.Enums;

namespace ExternalWebhookReceiverAPI.Application.Mappings.Hotmart
{
    public class HotmartWebhookMapper
    {
        public static ExternalWebhookReceiver ToExternalWebhookReceiver(
            HotmartWebhookDTO dto,
            BusinessUnit businessUnit,
            ExternalWebhookReceiverSourceType sourceType,
            DefaultUserService defaultUser)
        {
            return new ExternalWebhookReceiver
            {
                SourceType = sourceType,
                Status = ExternalWebhookReceiverStatus.Created,
                CompanyId = businessUnit.CompanyId,
                BusinessUnitId = businessUnit.BusinessUnitId,
                ExternalIdentifier = dto.Id,
                Payload = JsonSerializer.Serialize(dto),
                CreationUserId = defaultUser.DefaultUserId,
                UpdateUserId = defaultUser.DefaultUserId,
            };
        }
    }
}