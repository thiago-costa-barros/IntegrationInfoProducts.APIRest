using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdRepository(int userId);
        Task<User?> GetUserByLoginRepository(string login);
        Task<User?> GetUserByEmailRepository(string email);
        Task<User?> CreateUserRepository(User user);
        Task<User?> GetOrCreateUserSystemRepository(UserType type, [CallerMemberName] string method = "");
        Task<User?> UpdateUserRepository(int userId, User user);
        Task<bool> RemoveUserRepository(int userId);
    }
}
