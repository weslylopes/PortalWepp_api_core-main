using System;
using SylerBackend.Infra.Context;
using SylerBackend.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SylerBackend.Domain.Repositories;
using AutoMapper;
using SylerBackend.Service.Repository;

namespace SylerBackend.Service.Services
{
    public class MenuApp //: UserRepository
    {
        private IMenuRepository _rep;
        private readonly IMapper _mapper;

        public MenuApp(IMenuRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public new IList<Menu> GetAll()
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

        public IList<Menu> GetAllInFormulario()
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

        public Menu GetByGuid(string guid)
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

        public async Task<Menu> Create(Menu entity)
        {
            try
            {
                entity._id = Guid.NewGuid();
                entity._formulario = null;
                return await _rep.CreateAsync(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Menu> Update(string guid, Menu entity)
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

        public Menu MergeEntity(Menu source, Menu destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
