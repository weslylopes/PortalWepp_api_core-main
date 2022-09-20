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
    public class FormularioApp : GenericRepository<FormularioApp>
    {
        private IGenericRepository<Formulario> _rep;
        private readonly IMapper _mapper;

        public FormularioApp(IGenericRepository<Formulario> rep, StylerContext dbContext, IMapper mapper) : base(dbContext)
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

        public new IList<Formulario> GetAll()
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

        public Formulario GetByGuid(string guid)
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

        public async Task<Formulario> Create(Formulario entity)
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

        public async Task<Formulario> Update(string guid, Formulario entity)
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

        public Formulario MergeEntity(Formulario source, Formulario destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
