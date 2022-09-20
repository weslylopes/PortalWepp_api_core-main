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
    public class MenuClienteController : ControllerBase
    {
        private readonly ILogger _logger;

        public MenuClienteController(ILogger<MenuClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("MenuCliente")]
        public IList<MenuCliente> GetAll([FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get MenuCliente all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MenuCliente all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("MenuCliente/{guid}")]
        public MenuCliente GetGuid(string guid, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get MenuCliente/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("MenuCliente/cliente/{guid}")]
        public IList<MenuCliente> GetClienteGuid(string guid, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get MenuCliente/{guid} " + guid);
                return app.GetByClienteGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("MenuCliente/cliente/{clienteGuid}/user/{userGuid}")]
        public IList<MenuCliente> GetByClienteGuidByUserGuid(string clienteGuid, string userGuid, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Get MenuCliente/cliente/" + clienteGuid + "/user/" + userGuid);
                return app.GetByClienteGuidByUserGuid(clienteGuid, userGuid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("MenuCliente/{guid}")]
        public async Task<MenuCliente> Put(string guid, [FromBody]MenuCliente entity, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Put MenuCliente/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("MenuCliente")]
        public async Task<MenuCliente> Post([FromBody]MenuCliente entity, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Post MenuCliente ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("MenuCliente/{guid}")]
        public bool Delete(string guid, [FromServices] MenuClienteApp app)
        {
            try
            {
                _logger.LogInformation("Del MenuCliente/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del MenuCliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
