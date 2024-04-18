using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Domain.DataTransferObjects;
using Word_Game.Domain.Entities;

namespace Word_Game.Application.Abstractions.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(UserDTO userDTO)
        {
            var result = new User()
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                IsAdmin = false,
                Coins = 0
            };

            return await _userRepository.Create(result);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> UpdateAsync(UserDTO userDTO, Guid id)
        {
            var result = await _userRepository.GetByAny(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("try");
            }

            result.Username = userDTO.Username;
            result.Password = userDTO.Password;

            return await _userRepository.Update(result);
        }
    }
}
