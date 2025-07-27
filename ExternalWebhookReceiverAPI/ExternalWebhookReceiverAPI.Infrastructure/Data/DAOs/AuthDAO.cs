using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Interfaces.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs
{
    public class AuthDAO : IAuthDAO
    {
        public Task<IEnumerable<UserToken>> GetAllTokensByUserIdDAO(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken?> GetTokenByIdentifierDAO(Guid identifier, TokenType type)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken?> InsertTokenDAO(int userId, TokenType type, string token, DateTime expirationDate, Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken?> RevokeUserTokenDAO(Guid identifier, TokenType type)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken?> UpdateUserTokenDAO(Guid identifier, TokenType type, TokenStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
