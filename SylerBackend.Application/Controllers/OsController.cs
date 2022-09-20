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
    public class OsController : ControllerBase
    {
        private readonly ILogger _logger;

        public OsController(ILogger<OsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Os")]
        public IList<Os> GetAll([FromServices] OsApp app)
        {
            try
            {
                _logger.LogInformation("Get Os all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Os all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Os/{guid}")]
        public Os GetGuid(string guid, [FromServices] OsApp app)
        {
            try
            {
                _logger.LogInformation("Get Os/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Os/{guid}")]
        public async Task<Os> Put(string guid, [FromBody]Os entity, [FromServices] OsApp app)
        {
            try
            {
                _logger.LogInformation("Put Os/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Os")]
        public async Task<Os> Post([FromBody]Os entity, [FromServices] OsApp app)
        {
            try
            {
                _logger.LogInformation("Post Os ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Os/{guid}")]
        public bool Delete(string guid, [FromServices] OsApp app)
        {
            try
            {
                _logger.LogInformation("Del Os/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
