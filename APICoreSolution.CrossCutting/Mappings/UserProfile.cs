using APICoreSolution.Application.DTOs;
using APICoreSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICoreSolution.CrossCutting.Mappings
{
    public static class UserProfile
    {
        public static User MapToUser(this UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null) throw new ArgumentNullException(nameof(userCreateDTO));

            return new User
            {
                Login = userCreateDTO.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(userCreateDTO.Password),
                Email = userCreateDTO.Email,
                Phone = userCreateDTO.Phone

            };
        }
        public static UserDTO MapToUserDTO(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return new UserDTO
            {
                UserId = user.UserId,
                Login = user.Login,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}
