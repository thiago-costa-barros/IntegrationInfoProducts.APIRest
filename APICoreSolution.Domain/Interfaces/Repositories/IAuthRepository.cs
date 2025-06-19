using APICoreSolution.Domain.Common.Enums;
using APICoreSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<UserToken?> InsertTokenRepository(int userId, TokenType type, string token, DateTime expirationDate, Guid identifier);
        Task<IEnumerable<UserToken?>> GetTokensByUserIdRepository(int userId);
        Task<UserToken?> GetTokenByIdentifierRepository(Guid identifier, TokenType type);
        Task<bool> UpdateUserTokenRepository(int userId, Guid identifier, TokenType type, TokenStatus status);
        Task<bool> RevokeUserTokenRepository(int userId, Guid identifier, TokenType type);
    }
}
