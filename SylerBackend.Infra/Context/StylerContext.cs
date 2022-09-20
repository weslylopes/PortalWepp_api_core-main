using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SylerBackend.Domain.Entities;
using SylerBackend.Domain.Entities.System;
using SylerBackend.Infra.Config;
using SylerBackend.Infra.Config.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Context
{
    public class StylerContext : DbContext
    {
        public StylerContext(DbContextOptions<StylerContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<FieldsClient> FieldsClient { get; set; }
        public DbSet<Formulario> Formulario { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuCliente> MenuCliente { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<NoticiaGrupo> NoticiaGrupo { get; set; }
        public DbSet<Os> Os { get; set; }
        public DbSet<OsItem> OsItem { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilItem> PerfilItem { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PushCliente> PushCliente { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<StatusGrupo> StatusGrupo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<MultiLevel> MultiLevel { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<TypeLevel> TypeLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new FieldsClientConfig());
            modelBuilder.ApplyConfiguration(new FieldsConfig());
            modelBuilder.ApplyConfiguration(new FormularioConfig());
            modelBuilder.ApplyConfiguration(new MenuClienteConfig());
            modelBuilder.ApplyConfiguration(new MenuConfig());
            modelBuilder.ApplyConfiguration(new NoticiaConfig());
            modelBuilder.ApplyConfiguration(new NoticiaGrupoConfig());
            modelBuilder.ApplyConfiguration(new OsConfig());
            modelBuilder.ApplyConfiguration(new OsItemConfig());
            modelBuilder.ApplyConfiguration(new PerfilConfig());
            modelBuilder.ApplyConfiguration(new PerfilItemConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PushClienteConfig());
            modelBuilder.ApplyConfiguration(new StatusConfig());
            modelBuilder.ApplyConfiguration(new StatusGrupoConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserTypeConfig());
            modelBuilder.ApplyConfiguration(new ContatoConfig());
            modelBuilder.ApplyConfiguration(new MultiLevelConfig());
            modelBuilder.ApplyConfiguration(new RegiaoConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new MunicipioConfig());
            modelBuilder.ApplyConfiguration(new BairroConfig());
            modelBuilder.ApplyConfiguration(new TypeLevelConfig());
        }
    }
}
