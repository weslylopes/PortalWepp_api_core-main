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
    public class MenuController : ControllerBase
    {
        private readonly ILogger _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Menu")]
        public IList<Menu> GetAll([FromServices] MenuApp app)
        {
            try
            {
                _logger.LogInformation("Get Menu all");
                return app.GetAllInFormulario();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Menu all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Menu/{guid}")]
        public Menu GetGuid(string guid, [FromServices] MenuApp app)
        {
            try
            {
                _logger.LogInformation("Get Menu/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Menu/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Menu/{guid}")]
        public async Task<Menu> Put(string guid, [FromBody]Menu entity, [FromServices] MenuApp app)
        {
            try
            {
                _logger.LogInformation("Put Menu/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Menu/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Menu")]
        public async Task<Menu> Post([FromBody]Menu entity, [FromServices] MenuApp app)
        {
            try
            {
                _logger.LogInformation("Post Menu ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Menu/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Menu/{guid}")]
        public bool Delete(string guid, [FromServices] MenuApp app)
        {
            try
            {
                _logger.LogInformation("Del Menu/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Menu/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
