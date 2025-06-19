using APICoreSolution.Domain.Common.Enums;
using APICoreSolution.Domain.Entities;
using APICoreSolution.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public Task<UserToken?> GetTokenByIdentifierRepository(Guid identifier, TokenType type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserToken?>> GetTokensByUserIdRepository(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken?> InsertTokenRepository(int userId, TokenType type, string token, DateTime expirationDate, Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevokeUserTokenRepository(int userId, Guid identifier, TokenType type)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserTokenRepository(int userId, Guid identifier, TokenType type, TokenStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
