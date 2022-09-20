using System;
using SylerBackend.Infra.Context;
using SylerBackend.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SylerBackend.Infra.Repository;
using SylerBackend.Domain.Repositories;
using AutoMapper;

namespace SylerBackend.Service.Services
{
    public class PerfilApp //: PerfilRepository
    {
        private IPerfilRepository _rep;
        private IMenuClienteRepository _menuCliente;
        private IPerfilItemRepository _perfilItem;
        private readonly IMapper _mapper;

        public PerfilApp(
            IPerfilRepository rep, 
            IMenuClienteRepository menuCliente,
            IPerfilItemRepository perfilItem,
            StylerContext dbContext, IMapper mapper) : base()
        {
            try
            {
                this._rep = rep;
                this._mapper = mapper;
                this._menuCliente = menuCliente;
                this._perfilItem = perfilItem;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public new IList<Perfil> GetAll()
        {
            try
            {
                return _rep.GetAll().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Perfil GetByGuid(string guid)
        {
            try
            {
                //OBTEM O PERFIL DO CLIENTE COM A LISTA DE PERFIL_ITEM.
                var perfil = _rep.GetByPerfilGuidWithItens( new Guid(guid));

                if (perfil == null)
                    return null;

                //OBTEM OS MENUS_CLIENTES POR CLIENTE_GUID 
                var menuClients = _menuCliente.GetByClienteWithMenu(perfil._cod_cliente).ToList();

                //PASSA POR CADA UM PERFIL_ITEM E OBTEM O NOME DO TITULO NA LISTA DE MENU_CLIENTES.
                foreach (var item in perfil._perfil_itens)
                {
                    //item._titulo_menu = menuClients.Find(x => x._menu._formulario_id == item._form_hash)._titulo;
                }
                return null;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Perfil> GetByClienteGuidAsNoTrackingAsync(string guid)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x => x._cod_cliente == new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Perfil> GetListByPerfilGuidWithItens(string guid)
        {
            try
            {
                return _rep.GetListByPerfilGuidWithItens(new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Perfil> Create(Perfil entity)
        {
            try
            {
                entity._id = Guid.NewGuid();
                return await _rep.CreateAsync(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Perfil> CreateByCliente(Perfil entity)
        {
            try
            {
                //CRIAR O PERFIL
                List<PerfilItem> ListPerfilItem = new List<PerfilItem>();
                entity._id = Guid.NewGuid();
                var perfil = await _rep.CreateAsync(entity);

                //OBTER FORMGUID DOS MENUS DO CLIENTE
                var menuscClient = _menuCliente.GetByClienteWithMenu(entity._cod_cliente).ToList();

                foreach (var menuCli in menuscClient)
                {
                    ListPerfilItem.Add(new PerfilItem {
                        _perfil_id = perfil._id,
                        _cod_cliente = entity._cod_cliente,
                        _delete = false,
                        _read = false,
                        _write = false,
                        _menu_cliente_id = menuCli._id
                    });
                };

                await _perfilItem.SaveListPerfilItem(ListPerfilItem);
                return perfil;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Perfil> Update(string guid, Perfil entity)
        {
            try
            {
                var objDB = _rep.GetByIdAsync(x => x._id == new Guid(guid));
                return await _rep.Update(MergeEntity(objDB, entity));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Perfil> UpdatePerfilAndPerfilItem(string guid, Perfil entity)
        {
            try
            {
                //BUSCAR TODOS OS PERFIL_ITEM POR ARRAY DE ID
                var lsObjDB = _perfilItem.GetByFilterAsNoTrackingAsync(x => 
                                entity._perfil_itens.Select(s => s._id).Contains(x._id)).ToList();
                
                for (int i = 0; i < lsObjDB.Count(); i++)
                {
                    foreach (var item in entity._perfil_itens)
                    {//IDENTIFICAR CADA UM ITEM DO BANCO COM QUE CHEGOU E MERGIAR
                        if (lsObjDB[i]._id == item._id)
                        {
                            lsObjDB[i] = MergeEntityPerfilItem(lsObjDB[i], item);
                        }
                    }
                }
                await _perfilItem.Update(lsObjDB);
                                
                //ATUALIZAR O TITULO DO PERFIL
                var objDB = _rep.GetByIdAsync(x => x._id == new Guid(guid));
                var objPerfil = MergeEntity(objDB, entity);
                objPerfil._perfil_itens = null;
                    
                return await _rep.Update(objPerfil);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool Delete(string guid)
        {
            try
            {
                _rep.Remove(x => x._id == new Guid(guid));
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Perfil MergeEntity(Perfil source, Perfil destination)
        {
            return _mapper.Map(destination, source);
        }

        public PerfilItem MergeEntityPerfilItem(PerfilItem source, PerfilItem destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
