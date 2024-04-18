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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db)
            : base(db)
        {

        }
    }
}
