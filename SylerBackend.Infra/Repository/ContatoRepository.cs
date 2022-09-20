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
    public class ContatoRepository : GenericRepository<Contato>, IContatoRepository
    {
        private readonly StylerContext _dbContext;

        public ContatoRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Contato> GetByClienteWithStatus(Guid cod_cliente)
        {
            var response = _dbContext.Set<Contato>().AsQueryable();
            var query = response
                .Include(y => y._status)
                .Where(x=> x._cod_cliente == cod_cliente);

            return query;
        }

        public IQueryable<Contato> GetByClienteByUserWithStatus(Guid cod_cliente, Guid user)
        {
            var response = _dbContext.Set<Contato>().AsQueryable();
            var query = response
                .Include(y => y._status)
                .Where(x=> 
                    x._cod_cliente == cod_cliente && 
                    x._user_id_create == user);

            return query;
        }
    }
}
