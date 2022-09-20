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
    public class MenuClienteApp //: MenuClienteRepository
    {
        private IMenuClienteRepository _rep;
        private IPerfilItemRepository _perfilItem;
        private IPerfilRepository _perfil;
        private IUserRepository _user;
        private readonly IMapper _mapper;

        public MenuClienteApp(IMenuClienteRepository rep, IPerfilItemRepository perfilItem, IUserRepository user, IPerfilRepository perfil, StylerContext dbContext, IMapper mapper) : base()
        {
            try
            {
                this._rep = rep;
                this._mapper = mapper;
                this._perfilItem = perfilItem;
                this._user = user;
                this._perfil = perfil;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MenuCliente> GetAll()
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

        public MenuCliente GetByGuid(string guid)
        {
            try
            {
                return _rep.GetByIdAsync(x => x._id == new Guid(guid));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MenuCliente> GetByClienteGuid(string guid)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._cod_cliente == new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MenuCliente> GetByClienteGuidByUserGuid(string clienteGuid, string userGuid)
        {
            try
            {
                IList<MenuCliente> listaMenuCliente = new List<MenuCliente>();

                var perfil_id = _user.GetByIdAsync(x => x._id == new Guid(userGuid))._perfil_id;
                
                //OBTEM A LISTA DE PERFIL_ITEM COM MENU_CLIENTE DO PERFIL_ID INFORMADO.
                var perfilItens = _perfilItem.GetByPerfilGuidWithMenuCliente(perfil_id).ToList();

                foreach (var item in perfilItens)
                {
                    listaMenuCliente.Add(new MenuCliente {
                        _ativo = true,
                        _cod_cliente = new Guid(clienteGuid),
                        _icone = item._menu_cliente._icone,
                        _id = new Guid("00000000-0000-0000-0000-000000000000"),
                        _menu = null,
                        _menu_id = item._menu_cliente._menu_id,
                        _posicao = item._menu_cliente._posicao,
                        _titulo = item._menu_cliente._titulo,
                        _url = item._menu_cliente._url
                    });
                }

                return listaMenuCliente;


            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<MenuCliente> Create(MenuCliente entity)
        {
            try
            {
                entity._id = Guid.NewGuid();
                var obj =  await _rep.CreateAsync(entity);

                await UpdatePerfilCLiente(obj);

                return obj;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private async Task<bool> UpdatePerfilCLiente(MenuCliente obj)
        {
            try
            {
                List<PerfilItem> ListPerfilItem = new List<PerfilItem>(); 
                var lsPerfis = _perfil.GetByFilterAsync(x=> x._cod_cliente == obj._cod_cliente).ToList();

                foreach (var perfil in lsPerfis)
                {
                    ListPerfilItem.Add(new PerfilItem
                    {
                        _perfil_id = perfil._id,
                        _cod_cliente = perfil._cod_cliente,
                        _delete = false,
                        _read = false,
                        _write = false,
                        _menu_cliente_id = obj._id
                    });
                };

                await _perfilItem.SaveListPerfilItem(ListPerfilItem);

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<MenuCliente> Update(string guid, MenuCliente entity)
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

        public MenuCliente MergeEntity(MenuCliente source, MenuCliente destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
