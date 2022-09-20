using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SylerBackend.Domain.Entities;
using SylerBackend.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SylerBackend.Application.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    public class ContatoController : ControllerBase
    {
        private readonly ILogger _logger;

        public ContatoController(ILogger<ContatoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Contato")]
        public IList<Contato> GetAll([FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Get Contato all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Contato all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("ContatoByCliente/{guid}")]
        public IList<Contato> GetByCliente(string guid, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Get Contato/{guid}");
                return app.GetByCliente(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("ContatoByCliente/{clienteGuid}/byUser/{userGuid}")]
        public IList<Contato> GetByCliente(string clienteGuid, string userGuid, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Get Contato/{guid}");
                return app.GetByClienteByUser(clienteGuid, userGuid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Contato/{guid}")]
        public Contato GetGuid(string guid, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Get Contato/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        

        [HttpPut]
        [Route("Contato/{guid}")]
        public async Task<Contato> Put(string guid, [FromBody]Contato entity, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Put Contato/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Contato")]
        public async Task<Contato> Post([FromBody]Contato entity, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Post Contato ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Contato/{guid}")]
        public bool Delete(string guid, [FromServices] ContatoApp app)
        {
            try
            {
                _logger.LogInformation("Del Contato/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Contato/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
