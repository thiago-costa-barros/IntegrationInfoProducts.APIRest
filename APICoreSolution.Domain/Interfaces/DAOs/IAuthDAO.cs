using APICoreSolution.Domain.Common.Enums;
using APICoreSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.Domain.Interfaces.DAOs
{
    public interface IAuthDAO
    {
        Task<UserToken?> InsertTokenDAO(int userId, TokenType type, string token, DateTime expirationDate, Guid identifier);
        Task<UserToken?> GetTokenByIdentifierDAO(Guid identifier, TokenType type);
        Task<IEnumerable<UserToken>> GetAllTokensByUserIdDAO(int userId);
        Task<UserToken?> UpdateUserTokenDAO(Guid identifier, TokenType type, TokenStatus status);
        Task<UserToken?> RevokeUserTokenDAO(Guid identifier, TokenType type);
    }
}
