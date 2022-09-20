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
    public class PushClienteApp : GenericRepository<PushClienteApp>
    {
        private IGenericRepository<PushCliente> _rep;
        private readonly IMapper _mapper;

        public PushClienteApp(IGenericRepository<PushCliente> rep, StylerContext dbContext, IMapper mapper) : base(dbContext)
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

        public new IList<PushCliente> GetAll()
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

        public PushCliente GetByGuid(string guid)
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

        public IList<PushCliente> GetByClienteGuid(string guid)
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

        public async Task<PushCliente> Create(PushCliente entity)
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

        public async Task<PushCliente> Update(string guid, PushCliente entity)
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

        public PushCliente MergeEntity(PushCliente source, PushCliente destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
