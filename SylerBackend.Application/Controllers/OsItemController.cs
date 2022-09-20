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
    public class OsItemController : ControllerBase
    {
        private readonly ILogger _logger;

        public OsItemController(ILogger<OsItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("OsItem")]
        public IList<OsItem> GetAll([FromServices] OsItemApp app)
        {
            try
            {
                _logger.LogInformation("Get OsItem all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get OsItem all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("OsItem/{guid}")]
        public OsItem GetGuid(string guid, [FromServices] OsItemApp app)
        {
            try
            {
                _logger.LogInformation("Get OsItem/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get OsItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("OsItem/{guid}")]
        public async Task<OsItem> Put(string guid, [FromBody]OsItem entity, [FromServices] OsItemApp app)
        {
            try
            {
                _logger.LogInformation("Put OsItem/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put OsItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("OsItem")]
        public async Task<OsItem> Post([FromBody]OsItem entity, [FromServices] OsItemApp app)
        {
            try
            {
                _logger.LogInformation("Post OsItem ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get OsItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("OsItem/{guid}")]
        public bool Delete(string guid, [FromServices] OsItemApp app)
        {
            try
            {
                _logger.LogInformation("Del OsItem/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del OsItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
