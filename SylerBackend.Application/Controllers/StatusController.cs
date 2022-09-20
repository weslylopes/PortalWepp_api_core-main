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
    public class StatusController : ControllerBase
    {
        private readonly ILogger _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Status")]
        public IList<Status> GetAll([FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Get Status all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Status all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Status/StatusGrupo/{guid}")]
        public IList<Status> GetByStatusGrupoGuid(string guid, [FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Get Status all");
                return app.GetByStatusGrupoGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Status all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Status/{guid}")]
        public Status GetGuid(string guid, [FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Get Status/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Status/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Status/{guid}")]
        public async Task<Status> Put(string guid, [FromBody]Status entity, [FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Put Status/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Status/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Status")]
        public async Task<Status> Post([FromBody]Status entity, [FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Post Status ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Status/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Status/{guid}")]
        public bool Delete(string guid, [FromServices] StatusApp app)
        {
            try
            {
                _logger.LogInformation("Del Status/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Status/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
