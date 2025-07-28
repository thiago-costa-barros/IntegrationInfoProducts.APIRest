using ExternalWebhookReceiverAPI.Application.DTOs.Common;
using System.Text.Json;

namespace ExternalWebhookReceiverAPI.API.Filters
{
    public class ApiSuccessResponseFilter
    {
        public static ApiSuccessResponse CreateSuccessResponse(string message, JsonElement payload)
        {
            ApiSuccessResponse response = new ApiSuccessResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = message,
                Payload = JsonSerializer.SerializeToElement(payload)
            };

            return response;
        }
    }
}
