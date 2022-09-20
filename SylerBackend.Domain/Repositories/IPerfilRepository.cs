using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IPerfilRepository : IGenericRepository<Perfil>
    {
        Perfil GetByPerfilGuidWithItens(Guid perfil_guid);
        List<Perfil> GetListByPerfilGuidWithItens(Guid cliente_guid);
    }
}
