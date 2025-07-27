using ExternalWebhookReceiverAPI.Domain.Common.Enums;
using ExternalWebhookReceiverAPI.Domain.Entities;
using ExternalWebhookReceiverAPI.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExternalWebhookReceiverAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User?> CreateUserRepository(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetOrCreateUserSystemRepository(UserType type, [CallerMemberName] string method = "")
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailRepository(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIdRepository(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByLoginRepository(string login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserRepository(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserRepository(int userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}