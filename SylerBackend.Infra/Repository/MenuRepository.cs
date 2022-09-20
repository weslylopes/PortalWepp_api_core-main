using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System.Linq;

namespace SylerBackend.Infra.Repository
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly StylerContext _dbContext;

        public MenuRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Menu> GetAllWithFormulario()
        {
            var menu = _dbContext.Set<Menu>().AsQueryable();
            //todo: não retorna objeto de formulário agregado ao field
            var query = menu.Include(p => p._formulario);

            return query;
        }
    
    }
}
