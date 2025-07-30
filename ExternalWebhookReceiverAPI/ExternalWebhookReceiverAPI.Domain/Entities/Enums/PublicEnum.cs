using ExternalWebhookReceiverAPI.Domain.Common.Resources;
using System.ComponentModel.DataAnnotations;


namespace ExternalWebhookReceiverAPI.Domain.Entities.Enums
{
    public enum PublicEnum;
    
        public enum UserType
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0000")]
        ApiMethod = 0,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0001")]
        TeamUser = 1,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0002")]
        WorkerProcess = 2,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0003")]
        Integration = 3,

        [Display(ResourceType = typeof(UserMessages), Name = "ECM0004")]
        ScheduledTask = 4
    }

    public enum TokenType
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0005")]
        AccessToken = 1,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0006")]
        RefreshToken = 2
    }

    public enum TokenStatus
    {
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0007")]
        Active = 1,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0008")]
        Expired = 2,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0009")]
        Revoked = 3,
        [Display(ResourceType = typeof(UserMessages), Name = "ECM0010")]
        Blocked = 4
    }

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
}

