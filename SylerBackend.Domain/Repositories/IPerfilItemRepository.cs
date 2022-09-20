using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Domain.Repositories
{
    public interface IPerfilItemRepository : IGenericRepository<PerfilItem>
    {
        Task<List<PerfilItem>> SaveListPerfilItem(List<PerfilItem> perfilItens);

        List<PerfilItem> GetByPerfilGuidWithMenuCliente(Guid perfilId);
    }
}
