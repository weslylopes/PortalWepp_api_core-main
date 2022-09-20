using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SylerBackend.Domain.Entities;
using SylerBackend.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SylerBackend.Application.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    public class ClientesController: ControllerBase
    {
        private readonly ILogger _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Clientes")]
        public IList<Cliente> GetAll([FromServices] ClienteApp app) 
        {
            try
            {
                _logger.LogInformation("Get Clientes all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Clientes all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Clientes/{guid}")]
        public Cliente GetGuid(string guid, [FromServices] ClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get Clientes/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Clientes/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Clientes/{guid}")]
        public async Task<Cliente> Put(string guid, [FromBody]Cliente entity, [FromServices] ClienteApp app)
        {                        
            try
            {
                _logger.LogInformation("Put Clientes/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Clientes/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Clientes")]
        public async Task<Cliente> Post([FromBody]Cliente entity, [FromServices] ClienteApp app)
        {
            try
            {
                _logger.LogInformation("Post Clientes ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Clientes/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Clientes/{guid}")]
        public bool Delete(string guid, [FromServices] ClienteApp app)
        {
            try
            {
                _logger.LogInformation("Del Clientes/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Clientes/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
