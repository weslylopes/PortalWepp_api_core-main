using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Infra.Repository
{
    public class MenuClienteRepository : GenericRepository<MenuCliente>, IMenuClienteRepository
    {
        private readonly StylerContext _dbContext;

        public MenuClienteRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MenuCliente> GetByClienteWithMenu(Guid cod_cliente)
        {
            var menu = _dbContext.Set<MenuCliente>().AsQueryable();
            var query = menu.Where(x=> x._cod_cliente == cod_cliente).Include(p => p._menu);

            return query;
        }

        public async Task<bool> SaveListMenuCliente(List<MenuCliente> itens)
        {
            foreach (var item in itens)
            {
                item._id = Guid.NewGuid();
            }

            _dbContext.MenuCliente.AddRange(itens);
            await _dbContext.SaveChangesAsync(true);
            return true;
        }
    }
}
