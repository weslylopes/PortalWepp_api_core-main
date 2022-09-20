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
    public class FieldsClientController : ControllerBase
    {
        private readonly ILogger _logger;

        public FieldsClientController(ILogger<FieldsClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("FieldsClient")]
        public IList<FieldsClient> GetAll([FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldsClient all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsClient all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("GetAllWithClienteAndFields")]
        public IList<FieldsClient> GetAllWithClienteAndFields([FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldGetAllWithClienteAndFieldssClient all");
                return app.GetAllWithClienteAndFields();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get GetAllWithClienteAndFields all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("FieldsClientbyClient/{guidClient}/FieldsClientbyFormulario/{guidForm}")]
        public IList<FieldsClient> GetAllWithClienteAndFields(string guidClient, string guidForm, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldsClientbyClient/FieldsClientbyFormulario ");
                return app.GetbyClienteByForm(guidClient, guidForm);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsClientbyClient/FieldsClientbyFormulario :" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("FieldsClientbyClient/{guid}")]
        public IList<FieldsClient> GetAllWithCliente(string guid, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldsAllClient ");
                return app.GetByClienteGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsAllClient :" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("FieldsClient/{guid}")]
        public FieldsClient GetGuid(string guid, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Get FieldsClient/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsClient/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("FieldsClient/{guid}")]
        public async Task<FieldsClient> Put(string guid, [FromBody]FieldsClient entity, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Put FieldsClient/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put FieldsClient/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("FieldsClient")]
        public async Task<FieldsClient> Post([FromBody]FieldsClient entity, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Post FieldsClient ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get FieldsClient/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("FieldsClient/{guid}")]
        public bool Delete(string guid, [FromServices] FieldsClientApp app)
        {
            try
            {
                _logger.LogInformation("Del FieldsClient/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del FieldsClient/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
