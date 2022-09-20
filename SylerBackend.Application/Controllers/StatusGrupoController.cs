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
    public class StatusGrupoController : ControllerBase
    {
        private readonly ILogger _logger;

        public StatusGrupoController(ILogger<StatusGrupoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("StatusGrupo")]
        public IList<StatusGrupo> GetAll([FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get StatusGrupo all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get StatusGrupo all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("StatusGrupo/{guid}")]
        public StatusGrupo GetGuid(string guid, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get StatusGrupo/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get StatusGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("StatusGrupo/cliente/{clienteguid}/formulario/{fromguid}")]
        public StatusGrupo GetGuid(string clienteguid, string fromguid, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get StatusGrupo/cliente/{clienteguid}/formulario/{fromguid}");
                return app.GetByCLienteByFormulario(clienteguid, fromguid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get StatusGrupo/cliente/{clienteguid}/formulario/{fromguid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("StatusGrupo/codCliente/{guid}")]
        public IList<StatusGrupo> GetByClienteGuid(string guid, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get StatusGrupo/codCliente/{guid} " + guid);
                return app.GetByClienteGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get StatusGrupo/codCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("StatusGrupo/{guid}")]
        public async Task<StatusGrupo> Put(string guid, [FromBody]StatusGrupo entity, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Put StatusGrupo/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put StatusGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("StatusGrupo")]
        public async Task<StatusGrupo> Post([FromBody]StatusGrupo entity, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Post StatusGrupo ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get StatusGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("StatusGrupo/{guid}")]
        public bool Delete(string guid, [FromServices] StatusGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Del StatusGrupo/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del StatusGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
