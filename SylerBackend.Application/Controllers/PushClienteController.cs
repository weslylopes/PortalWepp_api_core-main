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
    public class PushClienteController : ControllerBase
    {
        private readonly ILogger _logger;

        public PushClienteController(ILogger<PushClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("PushCliente")]
        public IList<PushCliente> GetAll([FromServices] PushClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get PushCliente all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PushCliente all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("PushCliente/{guid}")]
        public PushCliente GetGuid(string guid, [FromServices] PushClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get PushCliente/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PushCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("PushCliente/{guid}")]
        public async Task<PushCliente> Put(string guid, [FromBody]PushCliente entity, [FromServices] PushClienteApp app)
        {
            try
            {
                _logger.LogInformation("Put PushCliente/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put PushCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("PushCliente")]
        public async Task<PushCliente> Post([FromBody]PushCliente entity, [FromServices] PushClienteApp app)
        {
            try
            {
                _logger.LogInformation("Post PushCliente ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PushCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("PushCliente/{guid}")]
        public bool Delete(string guid, [FromServices] PushClienteApp app)
        {
            try
            {
                _logger.LogInformation("Del PushCliente/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del PushCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
