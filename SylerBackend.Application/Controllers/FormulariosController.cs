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
    public class FormulariosController : ControllerBase
    {
        private readonly ILogger _logger;

        public FormulariosController(ILogger<FormulariosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Formulario")]
        public IList<Formulario> GetAll([FromServices] FormularioApp app)
        {
            try
            {
                _logger.LogInformation("Get Formulario all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Formulario all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Formulario/{guid}")]
        public Formulario GetGuid(string guid, [FromServices] FormularioApp app)
        {
            try
            {
                _logger.LogInformation("Get Formulario/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Formulario/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Formulario/{guid}")]
        public async Task<Formulario> Put(string guid, [FromBody]Formulario entity, [FromServices] FormularioApp app)
        {
            try
            {
                _logger.LogInformation("Put Formulario/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (string.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Formulario/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Formulario")]
        public async Task<Formulario> Post([FromBody]Formulario entity, [FromServices] FormularioApp app)
        {
            try
            {
                _logger.LogInformation("Post Formulario ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Formulario/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Formulario/{guid}")]
        public bool Delete(string guid, [FromServices] FormularioApp app)
        {
            try
            {
                _logger.LogInformation("Del Formulario/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Formulario/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
