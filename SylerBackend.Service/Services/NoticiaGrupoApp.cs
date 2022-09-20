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
    public class NoticiaGrupoApp : GenericRepository<NoticiaGrupoApp>
    {
        private IGenericRepository<NoticiaGrupo> _rep;
        private readonly IMapper _mapper;

        public NoticiaGrupoApp(IGenericRepository<NoticiaGrupo> rep, StylerContext dbContext, IMapper mapper) : base(dbContext)
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

        public new IList<NoticiaGrupo> GetAll()
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

        public NoticiaGrupo GetByGuid(string guid)
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

        public IList<NoticiaGrupo> GetByClienteGuid(string guid)
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
        
        public async Task<NoticiaGrupo> Create(NoticiaGrupo entity)
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

        public async Task<NoticiaGrupo> Update(string guid, NoticiaGrupo entity)
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

        public NoticiaGrupo MergeEntity(NoticiaGrupo source, NoticiaGrupo destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
