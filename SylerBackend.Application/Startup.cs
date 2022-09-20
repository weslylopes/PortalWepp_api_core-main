using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SylerBackend.Domain.Entities;
using SylerBackend.Infra.Context;
using SylerBackend.Service.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using SylerBackend.Service.Others;
using SylerBackend.Service.Repository;
using SylerBackend.Domain.Repositories;
using SylerBackend.Infra.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace SylerBackend.Application
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger, IHostingEnvironment env)
        {
            Configuration = configuration;
            _logger = logger;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(ConfigureJson);
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowMyOrigin"));
            //});

            services.Configure<FormGuid>(Configuration.GetSection("FormGuid"));
            services.Configure<TypeLevelGuid>(Configuration.GetSection("TypeLevelGuid"));

             var connection = @"<conexao>";

            services. AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Painel", Version = "v1" });
            });

            #pragma warning disable CS0618 // O tipo ou membro é obsoleto
            services.AddAutoMapper();
            #pragma warning restore CS0618 // O tipo ou membro é obsoleto
            services.AddDbContext<StylerContext>(options =>
            options.UseSqlServer(connection));

            services.AddScoped<IGenericRepository<Cliente>, GenericRepository<Cliente>>();
            services.AddScoped<IGenericRepository<UserType>, GenericRepository<UserType>>();
            services.AddScoped<IGenericRepository<Formulario>, GenericRepository<Formulario>>();
            services.AddScoped<IGenericRepository<PushCliente>, GenericRepository<PushCliente>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Noticia>, GenericRepository<Noticia>>();
            services.AddScoped<IGenericRepository<NoticiaGrupo>, GenericRepository<NoticiaGrupo>>();
            services.AddScoped<IGenericRepository<Os>, GenericRepository<Os>>();
            services.AddScoped<IGenericRepository<OsItem>, GenericRepository<OsItem>>();
            services.AddScoped<IGenericRepository<TypeLevel>, GenericRepository<TypeLevel>>();
            //services.AddScoped<IGenericRepository<MenuCliente>, GenericRepository<MenuCliente>>();
            //services.AddScoped<IGenericRepository<Perfil>, GenericRepository<Perfil>>();
            //services.AddScoped<IGenericRepository<PerfilItem>, GenericRepository<PerfilItem>>();
            //services.AddScoped<IGenericRepository<Menu>, GenericRepository<Menu>>();
            //services.AddScoped<IGenericRepository<FieldsClient>, GenericRepository<FieldsClient>>();
            //services.AddScoped<IGenericRepository<StatusGrupo>, GenericRepository<StatusGrupo>>();
            //services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            //services.AddScoped<IGenericRepository<Fields>, GenericRepository<Fields>>();

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IFieldsClientRepository, FieldsClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IFieldsRepository, FieldsRepository>();
            services.AddScoped<IMenuClienteRepository, MenuClienteRepository>();
            services.AddScoped<IPerfilItemRepository, PerfilItemRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IStatusGrupoRepository, StatusGrupoRepository>();
            services.AddScoped<IStatusGrupoRepository, StatusGrupoRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMultiLevelRepository, MultiLevelRepository>();
            _logger.LogInformation("Added full GenericRepository to services");

            services.AddTransient<ClienteApp>();
            services.AddTransient<FieldsApp>();
            services.AddTransient<FieldsClientApp>();
            services.AddTransient<FormularioApp>();
            services.AddTransient<MenuApp>();
            services.AddTransient<MenuClienteApp>();
            services.AddTransient<NoticiaApp>();
            services.AddTransient<NoticiaGrupoApp>();
            services.AddTransient<OsApp>();
            services.AddTransient<OsItemApp>();
            services.AddTransient<PerfilApp>();
            services.AddTransient<PerfilItemApp>();
            services.AddTransient<PersonApp>();
            services.AddTransient<PushClienteApp>();
            services.AddTransient<StatusApp>();
            services.AddTransient<StatusGrupoApp>();
            services.AddTransient<UserApp>();
            services.AddTransient<UserTypeApp>();
            services.AddTransient<ContatoApp>();
            services.AddTransient<MultiLevelApp>();
            _logger.LogInformation("Added full ClassServicesApp to services");

        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StylerContext context)
        {
            //app.UseCors(
            //    options => options.WithOrigins("http://localhost:42802").AllowAnyMethod()
            //);
            app.UseCors(builder => builder
            .WithOrigins("*")
            //.AllowAnyOrigin()
            //.AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            if (env.IsDevelopment())
            {
                _logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                #if DEBUG
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Painel");
                #else
                    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Painel");
                #endif
            });
                        
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(ImageConf.RetornaDiretorioImagemClienteG()),
                RequestPath = new PathString("/Images/Cliente/G")
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(ImageConf.RetornaDiretorioImagemClienteP()),
                RequestPath = new PathString("/Images/Cliente/P")
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
