using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using System.Linq;

namespace SylerBackend.Infra.Repository
{
    public class FieldsClientRepository : GenericRepository<FieldsClient>, IFieldsClientRepository
    {
        private readonly StylerContext _dbContext;

        public FieldsClientRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<FieldsClient> GetAllWithClienteAndFields()
        {
            var fieldsClient = _dbContext.Set<FieldsClient>().AsQueryable();
            //todo: não retorna objeto de formulário agregado ao field
            var query = fieldsClient
                .Include(p => p._cliente)
                .Include(y => y._fields)
                .Include(x => x._fields._formulario);

            return query;
        }
    }
}
