using AutoMapper;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Context
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, Cliente>();
            CreateMap<Fields, Fields>();
            CreateMap<FieldsClient, FieldsClient>();
            CreateMap<Formulario, Formulario>();
            CreateMap<Menu, Menu>();
            CreateMap<MenuCliente, MenuCliente>();
            CreateMap<Noticia, Noticia>();
            CreateMap<NoticiaGrupo, NoticiaGrupo>();
            CreateMap<Os, Os>();
            CreateMap<OsItem, OsItem>();
            CreateMap<Perfil, Perfil>();
            CreateMap<PerfilItem, PerfilItem>();
            CreateMap<Person, Person>();
            CreateMap<PushCliente, PushCliente>();
            CreateMap<Status, Status>();
            CreateMap<StatusGrupo, StatusGrupo>();
            CreateMap<User, User>();
            CreateMap<UserType, UserType>();

        }
    }
}
