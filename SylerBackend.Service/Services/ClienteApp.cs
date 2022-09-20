using AutoMapper;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using SylerBackend.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SylerBackend.Service.Services
{
    public class ClienteApp: GenericRepository<ClienteApp>
    {
        private IGenericRepository<Cliente> _rep;
        private readonly IMapper _mapper;

        public ClienteApp(IGenericRepository<Cliente> rep, StylerContext dbContext, IMapper mapper) : base(dbContext)
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

        #pragma warning disable CS0109
        public new IList<Cliente> GetAll()
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

        public Cliente GetByGuid(string guid)
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

        public IList<Cliente> GetByRazaoSocial(string value)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._razao_social == value).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Cliente> GetByFantasia(string value)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._fantasia == value).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Cliente> GetByCnpj(string value)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._cnpj == value).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Cliente> GetByCodigoAux(int value)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._codigo_aux == value).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Cliente> Create(Cliente entity)
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

        public async Task<Cliente> Update(string guid, Cliente entity)
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

        public Cliente MergeEntity(Cliente source, Cliente destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
