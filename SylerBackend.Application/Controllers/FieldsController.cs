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
    public class FieldsController : ControllerBase
    {
        private readonly ILogger _logger;

        public FieldsController(ILogger<FieldsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Fields")]
        public IList<Fields> GetAll([FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Get Fields all");
                return app.GetAllWithFormulario();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Fields all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("FieldsByFormulario/{guid}")]
        public IList<Fields> GetFieldsByFormulario(string guid, [FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldsByFormulario all");
                return app.GetByFormularioGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsByFormulario all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Fields/{guid}")]
        public Fields GetGuid(string guid, [FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Get Fields/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Fields/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Fields/{guid}")]
        public async Task<Fields> Put(string guid, [FromBody]Fields entity, [FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Put Fields/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Fields/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Fields")]
        public async Task<Fields> Post([FromBody]Fields entity, [FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Post Fields ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Fields/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Fields/{guid}")]
        public bool Delete(string guid, [FromServices] FieldsApp app)
        {
            try
            {
                _logger.LogInformation("Del Fields/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Fields/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
