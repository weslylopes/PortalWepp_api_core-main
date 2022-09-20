using System;
using SylerBackend.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using SylerBackend.Infra.Context;
using System.Collections.Generic;
using SylerBackend.Infra.Repository;
using SylerBackend.Domain.Repositories;
using AutoMapper;

namespace SylerBackend.Service.Services
{
    public class FieldsApp //: FieldsRepository
    {
        private IFieldsRepository _rep;
        private readonly IMapper _mapper;

        public FieldsApp(IFieldsRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public new IList<Fields> GetAll()
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

        public new IList<Fields> GetAllWithFormulario()
        {
            try
            {
                return _rep.GetAllWithFormulario().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Fields GetByGuid(string guid)
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

        public IList<Fields> GetByFormularioGuid(string formGuid)
        {
            try
            {
                return _rep.GetByFilterAsNoTrackingAsync(x =>
                x._formulario_id == new Guid(formGuid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Fields> Create(Fields entity)
        {
            try
            {
                entity._formulario = null;
                entity._id = Guid.NewGuid();
                return await _rep.CreateAsync(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Fields> Update(string guid, Fields entity)
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

        public Fields MergeEntity(Fields source, Fields destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
