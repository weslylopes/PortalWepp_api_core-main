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
    public class NoticiaGrupoController : ControllerBase
    {
        private readonly ILogger _logger;

        public NoticiaGrupoController(ILogger<NoticiaGrupoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("NoticiaGrupo")]
        public IList<NoticiaGrupo> GetAll([FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get NoticiaGrupo all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get NoticiaGrupo all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("NoticiaGrupo/{guid}")]
        public NoticiaGrupo GetGuid(string guid, [FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get NoticiaGrupo/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get NoticiaGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("NoticiaGrupo/codCliente/{guid}")]
        public IList<NoticiaGrupo> GetClienteGuid(string guid, [FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Get NoticiaGrupo/{guid} " + guid);
                return app.GetByClienteGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get NoticiaGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("NoticiaGrupo/{guid}")]
        public async Task<NoticiaGrupo> Put(string guid, [FromBody]NoticiaGrupo entity, [FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Put NoticiaGrupo/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put NoticiaGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("NoticiaGrupo")]
        public async Task<NoticiaGrupo> Post([FromBody]NoticiaGrupo entity, [FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Post NoticiaGrupo ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get NoticiaGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("NoticiaGrupo/{guid}")]
        public bool Delete(string guid, [FromServices] NoticiaGrupoApp app)
        {
            try
            {
                _logger.LogInformation("Del NoticiaGrupo/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del NoticiaGrupo/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
