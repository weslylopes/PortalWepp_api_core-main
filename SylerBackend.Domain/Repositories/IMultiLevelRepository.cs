using SylerBackend.Domain.Entities;
using SylerBackend.Domain.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Domain.Repositories
{
    public interface IMultiLevelRepository : IGenericRepository<MultiLevel>
    {
        IQueryable<MultiLevel> GetByCliente(Guid cod_cliente);

        IQueryable<MultiLevel> GetByClienteByUser(Guid cod_cliente, Guid user);

        List<MultiLevelResponseModel> GetEstructure(Guid cod_cliente);

        int LastId();
    }
}
