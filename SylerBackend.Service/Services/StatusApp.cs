﻿using System;
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
    public class StatusApp //: StatusRepository
    {
        private IStatusRepository _rep;
        private readonly IMapper _mapper;

        public StatusApp(IStatusRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public new IList<Status> GetAll()
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

        public Status GetByGuid(string guid)
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

        public Status GetByFormByClientDefault(string FormGuid, string ClientGuid)
        {
            try
            {
                return _rep.GetByFormByCliente(new Guid(FormGuid), new Guid(ClientGuid));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Status> GetByStatusGrupoGuid(string guid)
        {
            try
            {
                return _rep.GetByFilterAsync(x =>
                x._status_grupo_id == new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Status> Create(Status entity)
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

        public async Task<Status> Update(string guid, Status entity)
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

        public Status MergeEntity(Status source, Status destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
