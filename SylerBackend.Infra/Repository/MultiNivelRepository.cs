using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Domain.ResponseModel;
using SylerBackend.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Infra.Repository
{
    public class MultiLevelRepository : GenericRepository<MultiLevel>, IMultiLevelRepository
    {
        private readonly StylerContext _dbContext;

        public MultiLevelRepository(StylerContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MultiLevel> GetByCliente(Guid cod_cliente)
        {
            var response = _dbContext.Set<MultiLevel>().AsQueryable();
            var query = response
                .Where(x => x._cod_cliente == cod_cliente);

            return query;
        }

        public int LastId()
        {
            var obj = _dbContext.MultiLevel.OrderByDescending(u => u._id).FirstOrDefault();

            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj._id;
            }
        }

        public IQueryable<MultiLevel> GetByClienteByUser(Guid cod_cliente, Guid user)
        {
            var response = _dbContext.Set<MultiLevel>().AsQueryable();
            var query = response
                .Where(x =>
                    x._cod_cliente == cod_cliente &&
                    x._user_id == user);

            return query;
        }

        public List<MultiLevelResponseModel> GetEstructure(Guid cod_cliente)
        {
            List<MultiLevelResponseModel> lista = new List<MultiLevelResponseModel>();
            var multLevels = GetByCliente(cod_cliente);

            var nivel1 = multLevels.Where(c => c._id_pai == 0).ToList();

            foreach (var item in nivel1)
            {
                MultiLevelResponseModel obj = new MultiLevelResponseModel();
                obj.id = item._id;
                obj.name = getNameFk(item._fk_id, item._type_level_id, _dbContext);
                obj.fk_id = item._fk_id.ToString();
                obj.type_level_id = item._type_level_id.ToString();
                obj.childrens = GetChildren(multLevels.ToList(), item._id, _dbContext);

                lista.Add(obj);
            }
            return lista;
        }

        protected static string getNameFk(string fk_id, Guid level_type_id, StylerContext _dbContext)
        {
            int idFk = 0;
            int.TryParse(fk_id, out idFk);
            if(idFk == 0 && String.IsNullOrEmpty(fk_id))
            {
                return "";
            }

            switch (level_type_id.ToString().ToUpper())
            {
                case "F5EAEEFB-1D78-4060-8E16-08F6EF3FA562"://	BAIRRO
                    return _dbContext.Bairro.FirstOrDefault(x => x._id == idFk)._nome;
                case "B74B3458-9845-4B17-B5B0-0EEBD13831AF"://	MUNICIPIO
                    return _dbContext.Municipio.FirstOrDefault(x => x._id == idFk)._nome;
                case "5208248A-5106-4D96-A136-10843E60E110"://	ESTADO
                    return _dbContext.Estado.FirstOrDefault(x => x._id == idFk)._nome;
                case "78241018-9580-4F8E-B593-820D26237C1D"://	REGIAO
                    return _dbContext.Regiao.FirstOrDefault(x => x._id == idFk)._nome;
                case "8ADF3AB3-E019-4D81-830B-93AB78A37BB8"://	PESSOA
                    return _dbContext.Person.FirstOrDefault(x => x._id == new Guid(fk_id))._nome;
                default:
                    return "";
            }
        }

        protected static List<MultiLevelResponseModel> GetChildren(List<MultiLevel> comments, int parentId, StylerContext _dbContext)
        {
            var result = comments
                    .Where(c => c._id_pai == parentId)
                    .Select(c => new MultiLevelResponseModel
                    {
                        id = c._id,
                        name = getNameFk(c._fk_id, c._type_level_id, _dbContext),
                        fk_id = c._fk_id.ToString(),
                        type_level_id = c._type_level_id.ToString(),
                        childrens = GetChildren(comments, c._id, _dbContext)
                    });
            return result.ToList();
        }
    }
}
