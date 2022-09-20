using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SylerBackend.Domain.Entities;
using SylerBackend.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SylerBackend.Application.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    public class NoticiaController : ControllerBase
    {
        private readonly ILogger _logger;

        public NoticiaController(ILogger<NoticiaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Noticia")]
        public IList<Noticia> GetAll([FromServices] NoticiaApp app)
        {
            try
            {
                _logger.LogInformation("Get Noticia all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Noticia all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Noticia/{guid}")]
        public Noticia GetGuid(string guid, [FromServices] NoticiaApp app)
        {
            try
            {
                _logger.LogInformation("Get Noticia/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Noticia/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Noticia/{guid}")]
        public async Task<Noticia> Put(string guid, [FromBody]Noticia entity, [FromServices] NoticiaApp app)
        {
            try
            {
                _logger.LogInformation("Put Noticia/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Noticia/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Noticia")]
        public async Task<Noticia> Post([FromBody]Noticia entity, [FromServices] NoticiaApp app)
        {
            try
            {
                _logger.LogInformation("Post Noticia ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Noticia/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Noticia/{guid}")]
        public bool Delete(string guid, [FromServices] NoticiaApp app)
        {
            try
            {
                _logger.LogInformation("Del Noticia/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Noticia/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
