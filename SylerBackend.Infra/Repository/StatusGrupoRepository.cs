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
    public class StatusGrupoRepository : GenericRepository<StatusGrupo>, IStatusGrupoRepository
    {
        private readonly StylerContext _dbContext;

        public StatusGrupoRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public StatusGrupo GetByClienteByFormularioWithStatus(Guid cod_cliente, Guid formulario)
        {
            var response = _dbContext.Set<StatusGrupo>().AsQueryable();
            var query = response
                .Include(y => y._status)
                .Where(x => x._cod_cliente == cod_cliente && x._formulario_id == formulario);

            return query.First();
        }
    }
}
