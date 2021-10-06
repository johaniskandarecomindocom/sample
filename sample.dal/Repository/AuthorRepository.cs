using Microsoft.EntityFrameworkCore;
using OB_Net_Core_Tutorial.Model;
using OB_Net_Core_Tutorial.Repositories;

namespace OB_Net_Core_Tutorial.Repository
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(DbContext dbContext) : base(dbContext) { }
    }
}
