using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Domain.Repositories
{
    public interface IMenuClienteRepository : IGenericRepository<MenuCliente>
    {
        IQueryable<MenuCliente> GetByClienteWithMenu(Guid cod_cliente);
        Task<bool> SaveListMenuCliente(List<MenuCliente> itens);

        //COM GUID DO USER, OBTER O PERFIL E BUSCAR OS PERFIL_ITENS. 
        //SELECIONAR OS _menu_hash ONDE _read = true, E OBTER A LISTA DE MENUS com as urls.
        // MONTAR O RETORNO MENUCLIENTE 
    }
}
