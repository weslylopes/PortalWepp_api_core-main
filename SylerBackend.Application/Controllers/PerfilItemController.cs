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
    public class PerfilItemController : ControllerBase
    {
        private readonly ILogger _logger;

        public PerfilItemController(ILogger<PerfilItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("PerfilItem")]
        public IList<PerfilItem> GetAll([FromServices] PerfilItemApp app)
        {
            try
            {
                _logger.LogInformation("Get PerfilItem all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PerfilItem all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("PerfilItem/{guid}")]
        public PerfilItem GetGuid(string guid, [FromServices] PerfilItemApp app)
        {
            try
            {
                _logger.LogInformation("Get PerfilItem/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PerfilItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("PerfilItem/{guid}")]
        public async Task<PerfilItem> Put(string guid, [FromBody]PerfilItem entity, [FromServices] PerfilItemApp app)
        {
            try
            {
                _logger.LogInformation("Put PerfilItem/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put PerfilItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("PerfilItem")]
        public async Task<PerfilItem> Post([FromBody]PerfilItem entity, [FromServices] PerfilItemApp app)
        {
            try
            {
                _logger.LogInformation("Post PerfilItem ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PerfilItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("PerfilItem/{guid}")]
        public bool Delete(string guid, [FromServices] PerfilItemApp app)
        {
            try
            {
                _logger.LogInformation("Del PerfilItem/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del PerfilItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
