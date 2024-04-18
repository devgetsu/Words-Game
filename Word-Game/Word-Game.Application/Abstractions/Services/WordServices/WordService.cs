using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions.IServices;
using Word_Game.Domain.DataTransferObjects;
using Word_Game.Domain.Entities;

namespace Word_Game.Application.Abstractions.Services.WordServices
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        public async Task<Word> CreateAsync(WordDTO wordDTO)
        {
            var temp = new Word
            {
                _Word = wordDTO._Word,
                Description = wordDTO.Description,
            };

            var word = new WordDTO { _Word = temp._Word, Description = temp.Description };
            var res = await _wordRepository.Create(temp);
            return res;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            bool result = await _wordRepository.Delete(x=>x.Id == Id);
            return result;
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            var result = await _wordRepository.GetAll();
            return result;
        }

        public async Task<Word> GetByIdAsync(Guid id)
        {
            var result = await _wordRepository.GetByAny(x => x.Id == id);
            return result;
        }

        public async Task<Word> UpdateAsync(Guid id, WordDTO wordDTO)
        {
            var result = await _wordRepository.GetByAny(x=>x.Id == id);
            if (result == null)
            {
                throw new Exception("try");
            }
            result._Word = wordDTO._Word;
            result.Description = wordDTO.Description;
            
            var enrty = await _wordRepository.Update(result);
            return enrty;

        }
    }
}
