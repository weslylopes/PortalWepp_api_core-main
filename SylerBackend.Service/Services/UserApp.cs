using System;
using SylerBackend.Infra.Context;
using SylerBackend.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SylerBackend.Domain.ResponseModel;
using SylerBackend.Service.Repository;
using SylerBackend.Domain.Repositories;
using AutoMapper;

namespace SylerBackend.Service.Services
{
    public class UserApp //: UserRepository
    {
        private IUserRepository _rep;
        private IPerfilItemRepository _perfilItem;
        private IMenuClienteRepository _menuCliente;
        private readonly IMapper _mapper;

        public UserApp(IUserRepository rep, IPerfilItemRepository perfilItem, IMenuClienteRepository menuCliente, StylerContext dbContext, IMapper mapper) : base()
        {
            try
            {
                this._rep = rep;
                this._mapper = mapper;
                this._perfilItem = perfilItem;
                this._menuCliente = menuCliente;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<User> GetAll()
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

        public IList<User> GetByClienteGuid(string cod_cliente)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x => x._cod_cliente == new Guid(cod_cliente)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<User> GetByUserTypeByClienteGuid(string user_type_id, string cod_cliente)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x =>
                x._user_type_id == new Guid(user_type_id) && x._cod_cliente == new Guid(cod_cliente)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User GetByGuid(string guid)
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

        public async Task<User> Create(User entity)
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

        public async Task<User> CreateUserCliente(User entity)
        {
            try
            {
                //List<MenuCliente> listMenuClient = new List<MenuCliente>();
                entity._id = Guid.NewGuid();
                var user = await _rep.CreateAsync(entity);

                //OBTEM A LISTA DE ITENS DO PERFIL INFORMADO
                //var perfilItens = _perfilItem.GetByFilterAsNoTrackingAsync(x =>
                //                    x._perfil_id == entity._perfil_id &&
                //                    x._read == true).ToList();

                //OBTEM A LISTA DE MENUS DO CLIENTE INFORMADO
                //var menusClient = _menuCliente.GetByFilterAsNoTrackingAsync(x =>
                //                            x._cod_cliente == entity._cod_cliente).ToList();
                //if (perfilItens.Count == 0 || menusClient.Count == 0)
                //if (perfilItens.Count == 0)
                //{
                //    _rep.Remove(x => x._id == entity._id);
                //    throw new Exception("erro ao gerar menuCliente de usuário.");
                //}

                //var posicao = 1;
                //foreach (var item in perfilItens)
                //{
                //    //OBTEM O MENU_CLIENTE
                //    var objMenu = menusClient.FirstOrDefault(m => m._menu_id == item._menu_hash);
                //    if (objMenu != null)
                //    {
                //        listMenuClient.Add(new MenuCliente
                //        {
                //            _cod_cliente = entity._cod_cliente,
                //            _ativo = true,
                //            _icone = objMenu._icone,
                //            _menu_id = item._menu_hash,
                //            _posicao = posicao,
                //            _titulo = objMenu._titulo,
                //            _url = objMenu._url,
                //            _user_cliente = entity._id
                //        });
                //        posicao++;
                //    }
                //    else
                //    {
                //        _rep.Remove(x => x._id == entity._id);
                //        throw new Exception("erro ao gerar menuCliente de usuário.");
                //    }
                //}

                //var saved = await _menuCliente.SaveListMenuCliente(listMenuClient);
                //if (!saved)
                //{
                //    _rep.Remove(x => x._id == entity._id);
                //    throw new Exception("erro ao gerar menuCliente de usuário.");
                //}
                return user;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<User> Update(string guid, User entity)
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

        public UserResponseModel PostAuth(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user._email) || string.IsNullOrEmpty(user._senha))
                {
                    throw new Exception("Dados inválidos.");
                }

                User userTemp = _rep.GetByAuth(user);

                if (userTemp == null || userTemp._cod_cliente == null || userTemp._cod_cliente == default(Guid))
                {
                    throw new Exception("Usuário ou senha inválido.");
                }

                if (userTemp._ativo == false)
                {
                    throw new Exception("Usuário bloqueado."); ;
                }

                UserResponseModel userResponse = new UserResponseModel
                {
                    _id = userTemp._id,
                    _cod_cliente = userTemp._cod_cliente,
                    _nome = userTemp._nome,
                    _perfil = userTemp._perfil,
                    _usa_perfil = userTemp._usa_perfil,
                    _user_type = userTemp._user_type
                };

                return userResponse;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User MergeEntity(User source, User destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
