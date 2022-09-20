using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IFieldsClientRepository : IGenericRepository<FieldsClient>
    {
        IQueryable<FieldsClient> GetAllWithClienteAndFields();
    }
}
