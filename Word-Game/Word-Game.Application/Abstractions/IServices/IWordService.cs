using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Domain.DataTransferObjects;
using Word_Game.Domain.Entities;

namespace Word_Game.Application.Abstractions.IServices
{
    public interface IWordService
    {
        public Task<Word> CreateAsync(WordDTO wordDTO);
        public Task<Word> UpdateAsync(Guid id, WordDTO word);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<Word>> GetAllAsync();
        public Task<Word> GetByIdAsync(Guid id);
    }
}