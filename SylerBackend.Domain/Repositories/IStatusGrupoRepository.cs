using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IStatusGrupoRepository : IGenericRepository<StatusGrupo>
    {
        StatusGrupo GetByClienteByFormularioWithStatus(Guid cod_cliente, Guid formulario);
    }
}
