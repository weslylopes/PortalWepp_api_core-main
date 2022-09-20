using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.ResponseModel;
using SylerBackend.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SylerBackend.Application.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("User")]
        public IList<User> GetAll([FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Get User all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("User/cod_cliente/{clienteGuid}")]
        public IList<User> GetByUsertypeByclienteGuid( string clienteGuid, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Get User/cod_cliente/{clienteGuid}");
                return app.GetByClienteGuid(clienteGuid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User/cod_cliente/{clienteGuid}:" + msn, ex);
                throw new Exception(msn);
            }
        }


        [HttpGet]
        [Route("User/userType/{typeGuid}/cod_cliente/{clienteGuid}")]
        public IList<User> GetByUsertypeByclienteGuid(string typeGuid, string clienteGuid, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Get User/userType/{typeGuid}/cod_cliente/{clienteGuid}");
                return app.GetByUserTypeByClienteGuid(typeGuid, clienteGuid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User/userType/{typeGuid}/cod_cliente/{clienteGuid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("User/{guid}")]
        public User GetGuid(string guid, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Get User/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPost]
        [Route("Auth")]
        public UserResponseModel GetAuth([FromBody]User entity, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Post User Auth ", JsonConvert.SerializeObject(entity));
                return app.PostAuth(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get UserAuth/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("User/{guid}")]
        public async Task<User> Put(string guid, [FromBody]User entity, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Put User/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put User/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("User")]
        public async Task<User> Post([FromBody]User entity, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Post User ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPost]
        [Route("UserCliente")]
        public async Task<User> PostCreateUserCliente([FromBody]User entity, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Post User ", JsonConvert.SerializeObject(entity));
                return await app.CreateUserCliente(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get User/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("User/{guid}")]
        public bool Delete(string guid, [FromServices] UserApp app)
        {
            try
            {
                _logger.LogInformation("Del User/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del User/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
