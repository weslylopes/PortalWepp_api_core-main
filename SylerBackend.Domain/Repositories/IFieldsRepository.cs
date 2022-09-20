using SylerBackend.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SylerBackend.Domain.Repositories
{
    public interface IFieldsRepository : IGenericRepository<Fields>
    {
        IQueryable<Fields> GetAllWithFormulario();
    }
}
