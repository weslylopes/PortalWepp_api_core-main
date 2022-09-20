using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System.Linq;

namespace SylerBackend.Infra.Repository
{
    public class FieldsRepository : GenericRepository<Fields>, IFieldsRepository
    {
        private readonly StylerContext _dbContext;

        public FieldsRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Fields> GetAllWithFormulario()
        {
            var fields = _dbContext.Set<Fields>().AsQueryable();
            //todo: não retorna objeto de formulário agregado ao field
            var query = fields.Include(p => p._formulario);

            return query;
        }
    }
}
