using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Game.Application.Abstractions;
using Word_Game.Domain.Entities;
using Word_Game.Infrastructure.Persistance;

namespace Word_Game.Infrastructure.Repositories
{
    public class WordRepository : BaseRepository<Word>,IWordRepository
    {
        public WordRepository(ApplicationDbContext dbcontext)
         :base(dbcontext) { }
        
        
    }
}
