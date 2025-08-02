using CommonSolution.Entities.CoreSchema;
using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Entities.Enums;
using System.Text.Json;

namespace ExternalWebhookReceiverAPI.Application.Mappings.Hotmart
{
    public class HotmartWebhookMapper
    {
        public static ExternalWebhookReceiver ToExternalWebhookReceiver(
            HotmartWebhookDTO dto,
            Company company,
            ExternalWebhookReceiverSourceType sourceType)
        {
            return new ExternalWebhookReceiver
            {
                SourceType = sourceType,
                Status = ExternalWebhookReceiverStatus.Created,
                CompanyId = company.CompanyId,
                ExternalIdentifier = dto.Id,
                Payload = JsonSerializer.SerializeToElement(dto),
                Company = company,
            };
        }
    }
}