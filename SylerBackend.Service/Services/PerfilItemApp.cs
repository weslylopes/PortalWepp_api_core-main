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
    public class PerfilItemApp //: PerfilItemRepository
    {
        private IPerfilItemRepository _rep;
        private readonly IMapper _mapper;

        public PerfilItemApp(IPerfilItemRepository rep, StylerContext dbContext, IMapper mapper) : base()
        {
            try
            {
                this._rep = rep;
                this._mapper = mapper;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public new IList<PerfilItem> GetAll()
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

        public PerfilItem GetByGuid(string guid)
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

        public IList<PerfilItem> GetByClienteGuid(string guid)
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

        //public IList<PerfilItem> GetByClienteGuidFormGuid(string clienteGuid, string formGuid)
        //{
        //    try
        //    {
        //        return _rep.GetByFilterAsync(x =>
        //        x._cod_cliente == new Guid(clienteGuid) &&
        //        x._form_hash == new Guid(formGuid)).ToList();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        public IList<PerfilItem> GetByPerfilGuid(string guid)
        {
            try
            {
                return _rep.GetByFilterAsync(x =>
                x._perfil_id == new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<PerfilItem> Create(PerfilItem entity)
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

        public async Task<List<PerfilItem>> SaveListAssync(List<PerfilItem> lista)
        {
            try
            {
                return await _rep.SaveListPerfilItem(lista);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<PerfilItem> Update(string guid, PerfilItem entity)
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

        public async Task<IList<PerfilItem>> UpdateListByPerfilGuid(string perfilGuid, List<PerfilItem> entityList)
        {
            try
            {
                //TODO: IMPLEMENTAR API, QUANDO PERFIL_ITEM SOFRER UM UPDATE, DEVE REMOVER TODOS OS REGISTROS
                //DE USUÁRIOS QUE POSSUEM RELAÇÃO COM O PERFIL PAI DESTE ITEM,
                //E ADICIONAR NOVAMENTE NA TABELA MENU_CLIENTE APOS REMOVER.
                //DICA:: COM GUID DE PERFIL_ITEM, OBTER O GUID DE PERFIL,
                //BUSCAR TODOS OS USERS DESTE PERFIL, E COM O GUID DOS USERS, REMOVER OS REGISTROS DA MENU_CLIENTE

                IList<PerfilItem> listaUpdate = new List<PerfilItem>();
                //OBTEM TODOS OS REGISTROS DO BANCO A SEREM ATUALIZADOS
                var lsObjDB = _rep.GetByFilterAsNoTrackingAsync(x => entityList.Select(z=> z._id).Contains(x._id));

                foreach (var objDB in lsObjDB)
                {
                    foreach (var entity in entityList)
                    {
                        if (objDB._id == entity._id)
                        {
                            listaUpdate.Add(MergeEntity(objDB, entity));
                        }
                    }
                }  
                return await _rep.Update(listaUpdate);
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

        public PerfilItem MergeEntity(PerfilItem source, PerfilItem destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
