using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using CommonSolution.Entities.Common.Enums;
using System.Text.Json;
using CommonSolution.Entities.Common;
using CommonSolution.Entities.IntegrationSchema;

namespace ExternalWebhookReceiverAPI.Application.Mappings.Hotmart
{
    public class HotmartWebhookMapper
    {
        public static ExternalWebhookReceiver ToExternalWebhookReceiver(
            HotmartWebhookDTO dto,
            Company company,
            ExternalWebhookReceiverSourceType sourceType,
            DefaultUserService defaultUser)
        {
            return new ExternalWebhookReceiver
            {
                SourceType = sourceType,
                Status = ExternalWebhookReceiverStatus.Created,
                CompanyId = company.CompanyId,
                ExternalIdentifier = dto.Id,
                Payload = JsonSerializer.Serialize(dto),
                CreationUserId = defaultUser.DefaultUserId,
                UpdateUserId = defaultUser.DefaultUserId,
            };
        }
    }
}