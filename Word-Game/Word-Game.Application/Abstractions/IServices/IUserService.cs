using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Domain.DataTransferObjects;
using Word_Game.Domain.Entities;

namespace Word_Game.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> CreateAsync(UserDTO userDTO); 
        public Task<User> UpdateAsync(UserDTO userDTO, Guid id);
        public Task<IEnumerable<User>> GetAllAsync();
    }
}
