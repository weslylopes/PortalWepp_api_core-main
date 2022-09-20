using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Context;
using SylerBackend.Infra.Repository;
using SylerBackend.Service.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Service.Services
{
    public class ContatoApp //: ContatoRepository
    {
        private IContatoRepository _rep;
        private IStatusRepository _status;
        private readonly FormGuid _formGuid;
        private readonly IMapper _mapper;

        public ContatoApp(
            IContatoRepository rep, 
            IStatusRepository status,
            IOptions<FormGuid> formGuid,
            StylerContext dbContext, 
            IMapper mapper) : base()
        {
            try
            {
                _rep = rep;
                _mapper = mapper;
                _status = status;
                _formGuid = formGuid.Value;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<Contato> GetAll()
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

        public IList<Contato> GetByCliente(string guid)
        {
            try
            {                
                return _rep.GetByClienteWithStatus(new Guid(guid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Contato GetByGuid(string guid)
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

        public IList<Contato> GetByClienteByUser(string clienteGuid, string userGuid)
        {
            try
            {
                return _rep.GetByClienteByUserWithStatus(new Guid(clienteGuid), new Guid(userGuid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Contato> Create(Contato entity)
        {
            try
            {
                entity._status_id = _status.GetByFormByCliente(new Guid(_formGuid.FormContato), entity._cod_cliente)._id;
                entity._person_id = new Guid("00000000-0000-0000-0000-000000000000");
                if (string.IsNullOrEmpty(entity._user_id_create.ToString())){
                    entity._user_id_create = new Guid("00000000-0000-0000-0000-000000000000");
                }
                entity._data_cadastro = DateTime.Now;
                entity._data_ultimo_contato = DateTime.Now;
                entity._id = Guid.NewGuid();
                entity._status = null;
                return await _rep.CreateAsync(entity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<Contato> Update(string guid, Contato entity)
        {
            try
            {
                var objDB = _rep.GetByIdAsync(x => x._id == new Guid(guid));
                objDB._status = null;
                entity._status = null;
                    
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

        public Contato MergeEntity(Contato source, Contato destination)
        {
            return _mapper.Map(destination, source);
        }

    }


}
