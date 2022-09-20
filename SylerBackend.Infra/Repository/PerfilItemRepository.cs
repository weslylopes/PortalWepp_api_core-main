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
    public class PerfilItemRepository : GenericRepository<PerfilItem>, IPerfilItemRepository
    {
        private readonly StylerContext _dbContext;

        public PerfilItemRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PerfilItem>> SaveListPerfilItem(List<PerfilItem> perfilItens)
        {
            foreach (var item in perfilItens)
            {
                item._id = Guid.NewGuid();
            }
            
            _dbContext.PerfilItem.AddRange(perfilItens);
            await _dbContext.SaveChangesAsync(true);
            return perfilItens;
        }

        public List<PerfilItem> GetByPerfilGuidWithMenuCliente(Guid perfilId)
        {
            var entity = _dbContext.Set<PerfilItem>().AsQueryable();
            //todo: não retorna objeto de formulário agregado ao field
            var query = entity.Include(p => p._menu_cliente).Where(x=> 
            x._perfil_id == perfilId && x._read == true);

            return query.ToList();
        }
    }
}
