using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Repositories;
using SylerBackend.Domain.ResponseModel;
using SylerBackend.Infra.Context;
using SylerBackend.Service.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylerBackend.Service.Services
{
    public class MultiLevelApp
    {
        private IMultiLevelRepository _rep;
        private IPersonRepository _person;
        private readonly IMapper _mapper;
        private readonly TypeLevelGuid _typeLevelGuid;

        public int LastIdMultiLevel { get; private set; }

        public MultiLevelApp(
            IMultiLevelRepository rep,
            IPersonRepository person,
            StylerContext dbContext,
            IOptions<TypeLevelGuid> typeLevelGuid,
            IMapper mapper) : base()
        {
            try
            {
                _rep = rep;
                _mapper = mapper;
                _person = person;
                _typeLevelGuid = typeLevelGuid.Value;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MultiLevel> GetAll()
        {
            try
            {
                return _rep.GetAll().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MultiLevelResponseModel> GetByCliente(string guid)
        {
            try
            {
                List<MultiLevelResponseModel> ls = new List<MultiLevelResponseModel>();
                var persons = _person.GetByFilterAsNoTrackingAsync(x => x._cod_cliente == new Guid(guid));
                //int i = 1;
                //foreach (var person in persons)
                //{
                //    ls.Add(new MultiLevelResponseModel { id = i, name = person._nome, fk_id = person._id.ToString() });
                //    i = i + 1;
                //}

                return ls;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MultiLevel GetById(int id)
        {
            try
            {
                return _rep.GetByIdAsync(x => x._id == id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList<MultiLevelResponseModel> GetEstructureByClienteGuid(string clienteGuid)
        {
            try
            {
                var all = _rep.GetEstructure(new Guid(clienteGuid)).ToList();
                
                return all;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
       
        public IList<MultiLevel> GetByClienteByUser(string clienteGuid, string userGuid)
        {
            try
            {
                return _rep.GetByClienteByUser(new Guid(clienteGuid), new Guid(userGuid)).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IList<MultiLevel>> Create(string clienteGuid, string userGuid, List<MultiLevelResponseModel> entity)
        {
            try
            {
                var Node = entity;
                if (Node.Count > 0)
                {
                    List<MultiLevel> listLevel = new List<MultiLevel>();

                    listLevel = LevelGenerate(clienteGuid, userGuid, entity);
                    
                    if(await this.DeleteAllByClienteId(clienteGuid))
                    {
                        return await _rep.CreateAsync(listLevel);
                    }
                    else
                    {
                        throw new Exception("Erro ao excluir objetos do clienteId.");
                    }
                }
                else
                {
                    throw new Exception("Objeto não possui itens.");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private int NextId()
        {
            return LastIdMultiLevel = LastIdMultiLevel + 1;
        }

        private List<MultiLevel> LevelGenerate(string clienteGuid, string userGuid, List<MultiLevelResponseModel> entity)
        {
            try
            {
                List<MultiLevel> listLevel = new List<MultiLevel>();

                LastIdMultiLevel = _rep.LastId();

                foreach (var tree1 in entity)
                {   //LEVEL 1
                    MultiLevel node1 = new MultiLevel()
                    {
                        _id = NextId(),
                        _cod_cliente = new Guid(clienteGuid),
                        _id_pai = 0,
                        _nivel = 1,
                        _fk_id = tree1.fk_id,
                        _user_id = new Guid(userGuid),
                        _type_level_id = new Guid(tree1.type_level_id)
                    };
                    listLevel.Add(node1);
                    //LEVEL 2
                    foreach (var tree2 in tree1.childrens)
                    {
                        MultiLevel node2 = new MultiLevel()
                        {
                            _id = NextId(),
                            _cod_cliente = new Guid(clienteGuid),
                            _id_pai = node1._id,
                            _nivel = 2,
                            _fk_id = tree2.fk_id,
                            _user_id = new Guid(userGuid),
                            _type_level_id = new Guid(tree2.type_level_id)
                        };
                        listLevel.Add(node2);
                        //LEVEL 3
                        foreach (var tree3 in tree2.childrens)
                        {
                            MultiLevel node3 = new MultiLevel()
                            {
                                _id = NextId(),
                                _cod_cliente = new Guid(clienteGuid),
                                _id_pai = node2._id,
                                _nivel = 3,
                                _fk_id = tree3.fk_id,
                                _user_id = new Guid(userGuid),
                                _type_level_id = new Guid(tree3.type_level_id)
                            };
                            listLevel.Add(node3);
                            //LEVEL 4
                            foreach (var tree4 in tree3.childrens)
                            {
                                MultiLevel node4 = new MultiLevel()
                                {
                                    _id = NextId(),
                                    _cod_cliente = new Guid(clienteGuid),
                                    _id_pai = node3._id,
                                    _nivel = 4,
                                    _fk_id = tree4.fk_id,
                                    _user_id = new Guid(userGuid),
                                    _type_level_id = new Guid(tree4.type_level_id)
                                };
                                listLevel.Add(node4);
                                //LEVEL 5
                                foreach (var tree5 in tree4.childrens)
                                {
                                    MultiLevel node5 = new MultiLevel()
                                    {
                                        _id = NextId(),
                                        _cod_cliente = new Guid(clienteGuid),
                                        _id_pai = node4._id,
                                        _nivel = 5,
                                        _fk_id = tree5.fk_id,
                                        _user_id = new Guid(userGuid),
                                        _type_level_id = new Guid(tree5.type_level_id)
                                    };
                                    listLevel.Add(node5);
                                    //LEVEL 6
                                    foreach (var tree6 in tree5.childrens)
                                    {
                                        MultiLevel node6 = new MultiLevel()
                                        {
                                            _id = NextId(),
                                            _cod_cliente = new Guid(clienteGuid),
                                            _id_pai = node5._id,
                                            _nivel = 6,
                                            _fk_id = tree6.fk_id,
                                            _user_id = new Guid(userGuid),
                                            _type_level_id = new Guid(tree6.type_level_id)
                                        };
                                        listLevel.Add(node6);
                                        //LEVEL 7
                                        foreach (var tree7 in tree6.childrens)
                                        {
                                            MultiLevel node7 = new MultiLevel()
                                            {
                                                _id = NextId(),
                                                _cod_cliente = new Guid(clienteGuid),
                                                _id_pai = node4._id,
                                                _nivel = 7,
                                                _fk_id = tree7.fk_id,
                                                _user_id = new Guid(userGuid),
                                                _type_level_id = new Guid(tree7.type_level_id)
                                            };
                                            listLevel.Add(node7);
                                            //LEVEL 8
                                            foreach (var tree8 in tree7.childrens)
                                            {
                                                MultiLevel node8 = new MultiLevel()
                                                {
                                                    _id = NextId(),
                                                    _cod_cliente = new Guid(clienteGuid),
                                                    _id_pai = node7._id,
                                                    _nivel = 8,
                                                    _fk_id = tree8.fk_id,
                                                    _user_id = new Guid(userGuid),
                                                    _type_level_id = new Guid(tree8.type_level_id)
                                                };
                                                listLevel.Add(node8);
                                                //LEVEL 9
                                                foreach (var tree9 in tree8.childrens)
                                                {
                                                    MultiLevel node9 = new MultiLevel()
                                                    {
                                                        _id = NextId(),
                                                        _cod_cliente = new Guid(clienteGuid),
                                                        _id_pai = node8._id,
                                                        _nivel = 9,
                                                        _fk_id = tree9.fk_id,
                                                        _user_id = new Guid(userGuid),
                                                        _type_level_id = new Guid(tree9.type_level_id)
                                                    };
                                                    listLevel.Add(node9);
                                                    //LEVEL 10
                                                    foreach (var tree10 in tree9.childrens)
                                                    {
                                                        MultiLevel node10 = new MultiLevel()
                                                        {
                                                            _id = NextId(),
                                                            _cod_cliente = new Guid(clienteGuid),
                                                            _id_pai = node9._id,
                                                            _nivel = 10,
                                                            _fk_id = tree10.fk_id,
                                                            _user_id = new Guid(userGuid),
                                                            _type_level_id = new Guid(tree10.type_level_id)
                                                        };
                                                        listLevel.Add(node10);

                                                        if (tree10.childrens.Count > 0)
                                                        {
                                                            throw new Exception("Lista de dados possui mais de 10 níveis.");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }                                    
                                }
                            }
                        }
                    }
                }

                return listLevel;
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _rep.Remove(x => x._id == id);
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> DeleteAllByClienteId(string id)
        {
            try
            {
                await _rep.RemoveAll(x => x._cod_cliente == new Guid(id));
                return true; 
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Contato MergeEntity(Contato source, Contato destination)
        {
            return _mapper.Map(destination, source);
        }

    }
}
