using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Domain.Entities;

namespace Word_Game.Application.Abstractions.Services.LevelServices
{
    public class LevelService : ILevel
    {
        private readonly ILevelRepository _levelRepository;

        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<IEnumerable<Level>> GetLevelAsync()
        {
            return await _levelRepository.GetAll();
        }
    }
}
