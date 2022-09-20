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
    public class PersonController : ControllerBase
    {
        private readonly ILogger _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Person")]
        public IList<Person> GetAll([FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Get Person all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Person all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("PersonByClientId/{guid}")]
        public IList<Person> GetAllByCliente(string guid, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Get PersonAll/cliente/{guid} all");
                return app.GetAllByCliente(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PersonAll/cliente/{guid} all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("PersonByName/cliente/{guid}/name/{value}")]
        public IList<Person> GetAllByCliente(string guid, string value, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Get PersonByName/cliente/{guid}/name/{value} all");
                return app.GetByNomeAsync(value, guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get PersonByName/cliente/{guid}/name/{value} all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("Person/{guid}")]
        public Person GetGuid(string guid, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Get Person/{guid} " + guid);
                return app.GetByGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Person/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("Person/{guid}")]
        public async Task<Person> Put(string guid, [FromBody]Person entity, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Put Person/{guid} " + guid, JsonConvert.SerializeObject(entity));
                return await app.Update(guid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Person/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("Person")]
        public async Task<Person> Post([FromBody]Person entity, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Post Person ", JsonConvert.SerializeObject(entity));
                return await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Person/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("Person/{guid}")]
        public bool Delete(string guid, [FromServices] PersonApp app)
        {
            try
            {
                _logger.LogInformation("Del Person/{guid} " + guid);
                return app.Delete(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Del Person/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }
    }
}
