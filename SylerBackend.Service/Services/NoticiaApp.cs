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
    public class NoticiaApp : GenericRepository<NoticiaApp>
    {
        private IGenericRepository<Noticia> _rep;
        private readonly IMapper _mapper;

        public NoticiaApp(IGenericRepository<Noticia> rep, StylerContext dbContext, IMapper mapper) : base(dbContext)
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

        public new IList<Noticia> GetAll()
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

        public Noticia GetByGuid(string guid)
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

        public IList<Noticia> GetByNoticiaGrupoGuid(string guid)
        {
            try
            {
                return _rep.GetByFilterAsync(x =>
                x._noticia_grupo_id == new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Noticia> Create(Noticia entity)
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

        public async Task<Noticia> Update(string guid, Noticia entity)
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

        public Noticia MergeEntity(Noticia source, Noticia destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
