using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Interfaces.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Infrastructure.Data.DAOs
{
    public class UserDAO : IUserDAO
    {
        public Task<User?> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetOrCreateUserSystemAsync(UserType type, [CallerMemberName] string method = "")
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserAsync(int userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
