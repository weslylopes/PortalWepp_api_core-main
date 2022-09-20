using SylerBackend.Domain.Entities;
using SylerBackend.Infra.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SylerBackend.Infra.Repository;
using SylerBackend.Domain.Repositories;

namespace SylerBackend.Service.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly StylerContext _dbContext;

        public UserRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByAuth(User entity)
        {
            var user = _dbContext.Set<User>().AsQueryable();

            var query = user.Where(x => x._email == entity._email && x._senha == entity._senha)
                        .Include(p => p._perfil).Include(ut => ut._user_type);

            return query.FirstOrDefault();
        }
    }
}
