using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IContatoRepository : IGenericRepository<Contato>
    {
        IQueryable<Contato> GetByClienteWithStatus(Guid cod_cliente);

        IQueryable<Contato> GetByClienteByUserWithStatus(Guid cod_cliente, Guid user);
    }
}
