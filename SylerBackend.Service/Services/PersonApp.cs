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
    public class PersonApp
    {
        private IPersonRepository _rep;
        private readonly IMapper _mapper;

        public PersonApp(IPersonRepository rep, StylerContext dbContext, IMapper mapper) : base()
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

        public IList<Person> GetAll()
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

        public IList<Person> GetAllByCliente(string codCliente)
        {
            try
            {
                return _rep.GetByFilterAsync(x=> x._cod_cliente == new Guid(codCliente)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Person GetByGuid(string guid)
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

        public IList<Person> GetByNomeAsync(string name, string codCliente)
        {
            try
            {
                 return  _rep.GetByFilterAsync(x => x._nome.ToLower().Contains(name.ToLower()) && x._cod_cliente == new Guid(codCliente)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Person> GetByCpfCnpj(string value)
        {
            try
            {
                return _rep.GetByFilterAsync(x => x._cpf_cnpj == value).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
        public async Task<Person> Create(Person entity)
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

        public async Task<Person> Update(string guid, Person entity)
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

        public Person MergeEntity(Person source, Person destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
