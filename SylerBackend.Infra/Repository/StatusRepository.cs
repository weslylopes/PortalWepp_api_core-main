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
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        private readonly StylerContext _dbContext;

        public StatusRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Status GetByFormByCliente(Guid FormGuid, Guid ClientGuid)
        {
            var response = _dbContext.Set<Status>().AsQueryable();
            var query = response
                .Include(y => y._status_grupo)
                .FirstOrDefault(x => 
                x._status_grupo._cod_cliente == ClientGuid &&
                x._status_grupo._formulario_id == FormGuid);

            return query;
        }
    }
}
