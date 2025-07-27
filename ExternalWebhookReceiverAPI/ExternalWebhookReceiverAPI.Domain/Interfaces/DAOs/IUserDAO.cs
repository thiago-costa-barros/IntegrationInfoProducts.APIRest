using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Domain.Interfaces.DAOs
{
    public interface IUserDAO
    {
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByLoginAsync(string login);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetOrCreateUserSystemAsync(UserType type, [CallerMemberName] string method = "");
        Task<User?> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(int userId, User user);
        Task<bool> RemoveUserAsync(int userId);
    }
}
