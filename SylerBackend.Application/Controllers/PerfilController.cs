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
    public class PerfilController : ControllerBase
    {
        private readonly ILogger _logger;

        public PerfilController(ILogger<PerfilController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Perfil")]
        public IList<Perfil> GetAll([FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Get Perfil all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro get Perfil all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Perfil/cliente/{guid}")]
        public IList<Perfil> GetByClienteGuidAsNoTrackingAsync(string guid,[FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Get Perfil/cliente/{guid}");
                return app.GetByClienteGuidAsNoTrackingAsync(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro get Perfil/cliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("PerfilList/cliente/{guid}")]
        public IList<Perfil> GetListByPerfilGuidWithItens(string guid,[FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Get PerfilList/cliente/{guid}");
                return app.GetListByPerfilGuidWithItens(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro get PerfilList/cliente/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Perfil/{guid}")]
        public Perfil GetGuid(string guid, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Get Perfil/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro get Perfil/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Perfil/{guid}")]
        public async Task<Perfil> Put(string guid, [FromBody]Perfil entity, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Put Perfil/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro Put Perfil/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPut]
        [Route("PerfilAndPerfilItem/{guid}")]
        public async Task<Perfil> PutPerfilAndPerfilItem(string guid, [FromBody]Perfil entity, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Put PerfilAndPerfilItem/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.UpdatePerfilAndPerfilItem(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro Put PerfilAndPerfilItem/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Perfil")]
        public async Task<Perfil> Post([FromBody]Perfil entity, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Post Perfil ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro Post Perfil/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        /// <summary>
        /// /SALVA PERFIL E CRIA LISTA DE PERFIL_ITEM COM FORM_GUID DOS MENUS QUE O CLIENTE POSSUI.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="app"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SavePerfilAndPerfilItemByCliente")]
        public async Task<Perfil> PostByCliente([FromBody]Perfil entity, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Post PerfilByCliente :", JsonConvert.SerializeObject(entity));
                return await app.CreateByCliente(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro Post PerfilByCliente:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Perfil/{guid}")]
        public bool Delete(string guid, [FromServices] PerfilApp app)
        {
            try
            {
                _logger.LogInformation("Del Perfil/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Erro Del Perfil/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
