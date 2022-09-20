using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SylerBackend.Infra.Context
{
    public class DbInitializer
    {
        public static void Initialize(StylerContext context)
        {
            context.Database.EnsureCreated();

            //CLIENTE
            var clientes = new Cliente[]
            {
                new Cliente {
                    _id= new Guid("5ff653d6-75bf-4f61-ac99-6fb09e32fec7"),
                    _ativo = true,
                    _bairro = "bairro",
                    _celular1 = null,
                    _celular2 =null,
                    _celular3 =null,
                    _cidade ="cidade",
                    _cnpj ="12345657900",
                    _codigo_aux =0,
                    _data_cadastro =new DateTime().Date,
                    _dia_vencimento="0",
                    _email="EMAIL@EMAIL.com",
                    _endereco="Rua Brasil",
                    _estado="MG",
                    _fantasia="admin",
                    _razao_social="admin",
                    _responsavel="admin",
                    _telefone="12345678900"
                }
            };

            foreach (Cliente e in clientes)
            {
                if (context.Cliente.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.Cliente.Add(e);
                }
            }
            context.SaveChanges();

            //USERTYPE
            var userTypes = new UserType[]
            {
                new UserType{_id= new Guid("556C02A9-3703-44E7-8017-24E8A447A2D0"),_titulo = "ADMIN-CLIENTE"},
                new UserType{_id= new Guid("3D535902-6B97-49F7-AB09-47F2AA3D9897"),_titulo = "DEVELOPER"},
                new UserType{_id= new Guid("711D4C4C-36F5-4307-A73E-5CD484E967D9"),_titulo = "USER-PROSPECT"},
                new UserType{_id= new Guid("8108E0FB-9FEB-4386-93A8-D71B0E01296D"),_titulo = "USER-CLIENTE"}                    
            };
            foreach (UserType e in userTypes)
            {
                if (context.UserType.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.UserType.Add(e);
                }
            }
            context.SaveChanges();

            //PERFIL
            var perfilS = new Perfil[]
            {
                new Perfil{
                    _id = new Guid("39B4AB04-03E0-4CDB-854F-088D88C408DD"),
                    _cod_cliente = new Guid("5FF653D6-75BF-4F61-AC99-6FB09E32FEC7"),
                    _titulo = "DEVELOPER"}
            };
            foreach (Perfil e in perfilS)
            {
                if (context.Perfil.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.Perfil.Add(e);
                }
            }
            context.SaveChanges();

            //USER
            var users = new User[]
            {
                new User{
                    _id = new Guid("208F3A9E-5E42-44FA-9975-9C7554241C6B"),
                    _cod_cliente= new Guid("5FF653D6-75BF-4F61-AC99-6FB09E32FEC7"),
                    _nome = "admin",
                    _email = "email@email.com",
                    _senha = "123",
                    _ativo = true,
                    _usa_perfil = false,
                    _user_type_id = new Guid("3D535902-6B97-49F7-AB09-47F2AA3D9897"),
                    _perfil_id = new Guid("39B4AB04-03E0-4CDB-854F-088D88C408DD")
                }
            };
            foreach (User e in users)
            {
                if (context.User.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.User.Add(e);
                }
            }
            context.SaveChanges();

            //FORMULARIO
            var formularios = new Formulario[]
            {
                new Formulario{_id= new Guid("4558dac8-8fb7-4981-ae8c-d2a56cfb28a0"),_nome = "NOTICIA", _url="/noticias", _objetivo=""},
                new Formulario{_id= new Guid("0a2bff41-3c0c-43ee-be4a-a7ef8e921ee9"),_nome = "CLIENTE", _url="/clientes", _objetivo=""},
                new Formulario{_id= new Guid("6ba3e38a-0114-46cd-975e-ecf93ab28176"),_nome = "FORMULARIO", _url="/formularios", _objetivo=""},
                new Formulario{_id= new Guid("b2d1b016-54aa-4f0a-a207-57f7c3abb826"),_nome = "FIELDS", _url="/fields", _objetivo=""},
                new Formulario{_id= new Guid("425aee3f-fdf2-43f5-9418-1508beb9f2f1"),_nome = "FIELDS_CLIENT", _url="/fieldsClient", _objetivo=""},
                new Formulario{_id= new Guid("87da7f84-ffcc-478c-94e9-6ead770cb483"),_nome = "OS", _url="/ordemServico", _objetivo=""},
                new Formulario{_id= new Guid("90c1b0e9-8459-47d9-894b-9338a05f294c"),_nome = "CHAT", _url="/chat", _objetivo=""},
                new Formulario{_id= new Guid("cc7bc996-8ce9-4f6e-bb32-9e435ace8289"),_nome = "NOTICIA_GRUPO", _url="/gpnoticias", _objetivo=""},
                new Formulario{_id= new Guid("3e625d75-7577-4fb0-b422-2cdd91a5cf83"),_nome = "MENUS", _url="/menus", _objetivo=""},
                new Formulario{_id= new Guid("ca3b5d85-2c61-4ff9-8ac9-47c5b1f8b633"),_nome = "MENU_CLIENTE", _url="/menusClient", _objetivo=""},
                new Formulario{_id= new Guid("17f437af-3ec8-455b-a192-bd1097458921"),_nome = "PUSH", _url="/push", _objetivo=""},
                new Formulario{_id= new Guid("ecb4b4b4-a165-47b4-9281-6b46332ae303"),_nome = "USERS", _url="/users", _objetivo=""},
                new Formulario{_id= new Guid("df8a6c98-3327-4376-93ef-b7fe5d1dd9fa"),_nome = "USER_CLIENTE", _url="/usersCliente", _objetivo=""},
                new Formulario{_id= new Guid("8ce32dd0-fcac-4e5d-aadc-8e21363f4376"),_nome = "PERSON", _url="/person", _objetivo=""},
                new Formulario{_id= new Guid("5e3bef3c-436a-47a3-a783-64e6b1c29cfa"),_nome = "EMPRESA", _url="/empresa", _objetivo=""},
                new Formulario{_id= new Guid("71c2562f-11f9-4a9a-9842-e997a547cee1"),_nome = "EMPRESA_ITEM", _url="", _objetivo=""},
                new Formulario{_id= new Guid("40044f75-a8a1-431f-a2b9-ea83960b99d3"),_nome = "PERFIL", _url="/perfil", _objetivo=""}
                //new Formulario{_id= new Guid("48e56280-b5f6-4ee0-b786-0aa56594352b"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("e959e1f5-e5d6-4502-b19d-e6076668f394"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("d5b9f7a2-7001-4b38-b1c0-d4349e2233e2"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("8d3231c4-2e56-4fb8-ac8d-1ad40dc534d3"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("edb72cd7-cb25-47d4-b65d-4ce2aa5ffd5e"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("383c2482-1dc0-4491-a17f-393777a68583"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("3b3e9d6d-5dc1-4cb0-bf71-479d418b0bfe"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("4725658e-a1c4-45a4-91d2-9b59cb1f0378"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("eb28c274-a657-456e-9aeb-e2186aed5601"),_nome = "", _url="/", _objetivo=""}
                //new Formulario{_id= new Guid("d6050819-665e-4565-b5ea-b491d581e9e7"),_nome = "", _url="/", _objetivo=""}
            };
            foreach (Formulario e in formularios)
            {
                if (context.Formulario.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.Formulario.Add(e);
                }
            }
            context.SaveChanges();

            //USERTYPE
            var levelTypes = new TypeLevel[]
            {
                new TypeLevel{_id= new Guid("78241018-9580-4F8E-B593-820D26237C1D"),_titulo = "REGIAO"},
                new TypeLevel{_id= new Guid("5208248A-5106-4D96-A136-10843E60E110"),_titulo = "ESTADO"},
                new TypeLevel{_id= new Guid("B74B3458-9845-4B17-B5B0-0EEBD13831AF"),_titulo = "MUNICIPIO"},
                new TypeLevel{_id= new Guid("F5EAEEFB-1D78-4060-8E16-08F6EF3FA562"),_titulo = "BAIRRO"},
                new TypeLevel{_id= new Guid("8ADF3AB3-E019-4D81-830B-93AB78A37BB8"),_titulo = "PESSOA"}
            };
            foreach (TypeLevel e in levelTypes)
            {
                if (context.TypeLevel.Where(s => s._id == e._id).SingleOrDefault() == null)
                {
                    context.TypeLevel.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
