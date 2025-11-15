using ExternalWebhookReceiverAPI.Application.DTOs.Hotmart;
using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using FluentValidation;
using CommonSolution.Utils.Helpers;

namespace ExternalWebhookReceiverAPI.Application.Validators.Hotmart
{
    public class HotmartWebhookDTOValidate : AbstractValidator<HotmartWebhookDTO>
    {
        public HotmartWebhookDTOValidate()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(HotmartMessages.EXC0003, ValidationHelper.GetJsonPropertyName<HotmartWebhookDTO>(nameof(HotmartWebhookDTO.Id))));
            RuleFor(x => x.CreationDate)
                .GreaterThan(0)
                .WithMessage(string.Format(HotmartMessages.EXC0004, ValidationHelper.GetJsonPropertyName<HotmartWebhookDTO>(nameof(HotmartWebhookDTO.CreationDate))));
            RuleFor(x => x.Event)
                .NotEmpty()
                .WithMessage(string.Format(HotmartMessages.EXC0003, ValidationHelper.GetJsonPropertyName<HotmartWebhookDTO>(nameof(HotmartWebhookDTO.Event))));
            RuleFor(x => x.Version)
                .NotEmpty()
                .WithMessage(string.Format(HotmartMessages.EXC0003, ValidationHelper.GetJsonPropertyName<HotmartWebhookDTO>(nameof(HotmartWebhookDTO.Version))));
            RuleFor(x => x.Data)
                .NotEmpty()
                .WithMessage(string.Format(HotmartMessages.EXC0003, ValidationHelper.GetJsonPropertyName<HotmartWebhookDTO>(nameof(HotmartWebhookDTO.Data))));
        }
    }

}
