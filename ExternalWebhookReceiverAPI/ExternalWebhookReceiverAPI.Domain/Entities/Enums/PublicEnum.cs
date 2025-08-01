using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using System.ComponentModel.DataAnnotations;


namespace ExternalWebhookReceiverAPI.Domain.Entities.Enums
{
    public enum PublicEnum;

    public enum HotmartPurchaseEventType
    {
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0001")]
        PURCHASE_APPROVED = 1,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0002")]
        PURCHASE_CANCELED = 2,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0003")]
        PURCHASE_COMPLETE = 3,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0004")]
        PURCHASE_BILLET_PRINTED = 4,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0005")]
        PURCHASE_PROTEST = 5,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0006")]
        PURCHASE_REFUNDED = 6,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0007")]
        PURCHASE_CHARGEBACK = 7,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0008")]
        PURCHASE_EXPIRED = 8,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0009")]
        PURCHASE_DELAYED = 9
    }

    public enum ExternalWebhookReceiverSourceType
    {
        Hotmart = 1,
        Udemy = 2,
    }

    public enum ExternalWebhookReceiverStatus
    {
        Created = 0,
        Pending = 1,
        Proccessed = 2,
        Error = 3,
    }

    public enum ExternalAuthenticationType
    {
        Hotmart = 1,
        Udemy = 2,
    }
}

