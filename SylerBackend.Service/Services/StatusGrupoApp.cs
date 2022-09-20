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
    public class StatusGrupoApp //: StatusGrupoRepository
    {
        private IStatusGrupoRepository _rep;
        private readonly IMapper _mapper;

        public StatusGrupoApp(IStatusGrupoRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public new IList<StatusGrupo> GetAll()
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

        public StatusGrupo GetByGuid(string guid)
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

        public StatusGrupo GetByCLienteByFormulario(string clienteGuid,string formularioGuid)
        {
            try
            {
                return _rep.GetByClienteByFormularioWithStatus(new Guid(clienteGuid), new Guid(formularioGuid));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<StatusGrupo> GetByClienteGuid(string guid)
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

        public async Task<StatusGrupo> Create(StatusGrupo entity)
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

        public async Task<StatusGrupo> Update(string guid, StatusGrupo entity)
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

        public StatusGrupo MergeEntity(StatusGrupo source, StatusGrupo destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
