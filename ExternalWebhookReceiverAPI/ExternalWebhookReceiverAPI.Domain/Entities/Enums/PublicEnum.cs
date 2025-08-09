using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using System.ComponentModel.DataAnnotations;


namespace ExternalWebhookReceiverAPI.Domain.Entities.Enums
{
    public enum HotmartWebhookEventType
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
        PURCHASE_DELAYED = 9,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0010")]
        SUBSCRIPTION_CANCELLATION = 10,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0011")]
        SWITCH_PLAN = 11,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0012")]
        PURCHASE_OUT_OF_SHOPPING_CART = 12,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0013")]
        UPDATE_SUBSCRIPTION_CHARGE_DATE = 13,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0014")]
        CLUB_FIRST_ACCESS = 14,
        [Display(ResourceType = typeof(HotmartMessages), Name = "HWB0015")]
        CLUB_MODULE_COMPLETED = 15,
    }
}

