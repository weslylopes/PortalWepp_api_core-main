using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.ResponseModel;
using SylerBackend.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SylerBackend.Application.Controllers
{
    public class MultiLevelController : ControllerBase
    {
        private readonly ILogger _logger;

        public MultiLevelController(ILogger<MultiLevelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("MultiLevel")]
        public IList<MultiLevel> GetAll([FromServices] MultiLevelApp app)
        {
            try
            {
                _logger.LogInformation("Get MultiLevel all");
                return app.GetAll();
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MultiLevel all:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("MultiLevel/ClienteGuid/{guid}")]
        public IList<MultiLevelResponseModel> GetGuid(string guid, [FromServices] MultiLevelApp app)
        {
            try
            {
                _logger.LogInformation("Get MultiLevel/ClienteGuid/ " + guid);
                return app.GetByCliente(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MultiLevel/ClienteGuid/:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpGet]
        [Route("GetEstructure/ClienteGuid/{guid}")]
        public IList<MultiLevelResponseModel> GetEstructureByClienteGuid(string guid, [FromServices] MultiLevelApp app)
        {
            try
            {
                _logger.LogInformation("Get MultiLevel/ClienteGuid/ " + guid);
                return app.GetEstructureByClienteGuid(guid);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get MultiLevel/ClienteGuid/:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpPut]
        [Route("MultiLevelPersons/ClienteGuid/{clienteGuid}/user/{userGuid}")]
        public async Task<IList<MultiLevel>> Put(string clienteGuid, string userGuid, [FromBody]List<MultiLevelResponseModel> entity, [FromServices] MultiLevelApp app)
        {
            try
            {
                //_logger.LogInformation("Put Os/{" +clienteGuid+"}/user/{" + userGuid+ "}", JsonConvert.SerializeObject(entity));
                return await app.Create(clienteGuid, userGuid, entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("Put Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }

        }

        [HttpPost]
        [Route("MultiLevel")]
        public async Task<MultiLevel> Post([FromBody]MultiLevel entity, [FromServices] MultiLevelApp app)
        {
            try
            {
                _logger.LogInformation("Post Os ", JsonConvert.SerializeObject(entity));
                return null; // await app.Create(entity);
            }
            catch (ArgumentException ex)
            {
                string msn = ex.Message + " {" + (String.IsNullOrEmpty(ex.InnerException.Message) ? "" : ex.InnerException.Message) + "}";
                _logger.LogError("get Os/{guid}:" + msn, ex);
                throw new Exception(msn);
            }
        }

        [HttpDelete]
        [Route("MultiLevel/{id}")]
        public bool Delete(int id, [FromServices] MultiLevelApp app)
        {
            try
            {
                _logger.LogInformation("Del MultiLevel/{id} " + id);
                return app.Delete(id);
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
