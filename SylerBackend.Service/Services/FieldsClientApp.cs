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
    public class FieldsClientApp //: FieldsClientRepository
    {
        private IFieldsClientRepository _rep;
        private readonly IMapper _mapper;

        public FieldsClientApp(IFieldsClientRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public IList<FieldsClient> GetAll()
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

        public FieldsClient GetByGuid(string guid)
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
        
        public IList<FieldsClient> GetByClienteGuid(string guid)
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

        public IList<FieldsClient> GetbyClienteByForm(string guidClient, string guidForm)
        {
            try
            {
                return _rep.GetByFilterAsync(x => 
                x._cod_cliente == new Guid(guidClient) &&
                x._fields._formulario_id == new Guid(guidForm)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<FieldsClient> GetAllWithClienteAndFields()
        {
            try
            {
                return _rep.GetAllWithClienteAndFields().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<FieldsClient> GetByClienteGuidFormGuid(string clienteGuid, string formGuid)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x => 
                x._cod_cliente == new Guid(clienteGuid) &&
                x._fields._formulario_id == new Guid(formGuid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<FieldsClient> GetByFormularioGuid(string formGuid)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x =>
                x._fields._formulario_id == new Guid(formGuid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<FieldsClient> Create(FieldsClient entity)
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

        public async Task<FieldsClient> Update(string guid, FieldsClient entity)
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

        public FieldsClient MergeEntity(FieldsClient source, FieldsClient destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
