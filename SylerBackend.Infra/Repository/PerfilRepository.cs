using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Infra.Repository
{
    public class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        private readonly StylerContext _dbContext;

        public PerfilRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Perfil GetByPerfilGuidWithItens(Guid perfil_guid)
        {
            var response = _dbContext.Set<Perfil>().AsQueryable();
            var query = response
                .Include(y => y._perfil_itens)
                .FirstOrDefault(x => x._id == perfil_guid);

            return query;
        }
        public List<Perfil> GetListByPerfilGuidWithItens(Guid cliente_guid)
        {
            var response = _dbContext.Set<Perfil>().AsQueryable();
            var query = response
                .Include("_perfil_itens._menu_cliente")
                .Where(x => x._cod_cliente == cliente_guid);
            var ls = query.ToList();
            return ls;
        }
    }
}
