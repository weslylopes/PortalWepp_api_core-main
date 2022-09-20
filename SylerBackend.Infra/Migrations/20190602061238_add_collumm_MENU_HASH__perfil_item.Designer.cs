﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SylerBackend.Infra.Context;

namespace SylerBackend.Infra.Migrations
{
    [DbContext(typeof(StylerContext))]
    [Migration("20190602061238_add_collumm_MENU_HASH__perfil_item")]
    partial class add_collumm_MENU_HASH__perfil_item
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SylerBackend.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<string>("_bairro")
                        .HasColumnName("BAIRRO");

                    b.Property<string>("_celular1")
                        .HasColumnName("CELULAR_1");

                    b.Property<string>("_celular2")
                        .HasColumnName("CELULAR_2");

                    b.Property<string>("_celular3")
                        .HasColumnName("CELULAR_3");

                    b.Property<string>("_cidade")
                        .HasColumnName("CIDADE");

                    b.Property<string>("_cnpj")
                        .HasColumnName("CPF_CNPJ");

                    b.Property<int>("_codigo_aux")
                        .HasColumnName("CODIGO_AUX");

                    b.Property<DateTime>("_data_cadastro")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<string>("_dia_vencimento")
                        .HasColumnName("DIA_VENC");

                    b.Property<string>("_email")
                        .HasColumnName("EMAIL");

                    b.Property<string>("_endereco")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("_estado")
                        .HasColumnName("ESTADO");

                    b.Property<string>("_fantasia")
                        .IsRequired()
                        .HasColumnName("FANTASIA");

                    b.Property<string>("_razao_social")
                        .HasColumnName("RAZAO_SOCIAL");

                    b.Property<string>("_responsavel")
                        .HasColumnName("NOME_RESP");

                    b.Property<string>("_telefone")
                        .HasColumnName("TELEFONE");

                    b.HasKey("_id");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Contato", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_comentario")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("_data_cadastro")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<DateTime>("_data_nascimento")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<DateTime>("_data_ultimo_contato")
                        .HasColumnName("DATA_ULTIMO_CONTATO");

                    b.Property<string>("_email")
                        .HasColumnName("EMAIL")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_nome")
                        .HasColumnName("NOME")
                        .HasColumnType("NVARCHAR(70)")
                        .HasMaxLength(70);

                    b.Property<Guid>("_person_id")
                        .HasColumnName("PERSON_ID");

                    b.Property<Guid>("_status_id")
                        .HasColumnName("STATUS_ID");

                    b.Property<string>("_telefone")
                        .HasColumnName("TELEFONE")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_person_id");

                    b.HasIndex("_status_id");

                    b.ToTable("CONTATO");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Fields", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_formulario_id")
                        .HasColumnName("FORMULARIO_ID");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_size")
                        .HasColumnName("SIZE")
                        .HasColumnType("NVARCHAR(10)")
                        .HasMaxLength(10);

                    b.Property<string>("_type")
                        .HasColumnName("TYPE")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.HasKey("_id");

                    b.HasIndex("_formulario_id");

                    b.ToTable("FIELDS");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.FieldsClient", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<Guid>("_fields_id")
                        .HasColumnName("FIELD_ID");

                    b.Property<string>("_grid_titulo")
                        .HasColumnName("GRID_TITULO")
                        .HasColumnType("NVARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("_is_Valida")
                        .HasColumnName("IS_VALIDA");

                    b.Property<bool>("_is_coluna_grid")
                        .HasColumnName("IS_COLUNA_GRID");

                    b.Property<string>("_titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_fields_id");

                    b.ToTable("FIELDS_CLIENTE");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Formulario", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasColumnName("NOME");

                    b.Property<string>("_objetivo")
                        .IsRequired()
                        .HasColumnName("OBJETIVO");

                    b.Property<string>("_url")
                        .IsRequired()
                        .HasColumnName("URL");

                    b.HasKey("_id");

                    b.ToTable("FORMULARIO");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("_formulario_id")
                        .HasColumnName("FORMULARIO_ID");

                    b.Property<string>("_icone")
                        .IsRequired()
                        .HasColumnName("GRID_TITULO")
                        .HasColumnType("NVARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<string>("_titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_url")
                        .IsRequired()
                        .HasColumnName("URL")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("_id");

                    b.HasIndex("_formulario_id");

                    b.ToTable("MENU");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.MenuCliente", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_icone")
                        .IsRequired()
                        .HasColumnName("ICONE");

                    b.Property<Guid>("_menu_id")
                        .HasColumnName("MENU_ID");

                    b.Property<int>("_posicao")
                        .HasColumnName("POSICAO");

                    b.Property<string>("_titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(30)")
                        .HasMaxLength(30);

                    b.Property<string>("_url")
                        .IsRequired()
                        .HasColumnName("URL")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("_user_cliente")
                        .HasColumnName("USER_CLIENTE");

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_menu_id");

                    b.HasIndex("_user_cliente");

                    b.ToTable("MENU_CLIENTE");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Noticia", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<DateTime>("_data_final")
                        .HasColumnName("DATA_FINAL");

                    b.Property<DateTime>("_data_inicial")
                        .HasColumnName("DATA_INICIAL");

                    b.Property<string>("_desc_curta")
                        .IsRequired()
                        .HasColumnName("DESC_CURTA")
                        .HasColumnType("NVARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("_desc_longa")
                        .IsRequired()
                        .HasColumnName("DESC_LONG")
                        .HasColumnType("NVARCHAR(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("_imagem")
                        .IsRequired()
                        .HasColumnName("IMAGEM")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("_noticia_grupo_id")
                        .HasColumnName("NOTICIA_GRUPO_ID");

                    b.Property<string>("_titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_noticia_grupo_id");

                    b.ToTable("NOTICIA");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.NoticiaGrupo", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ATIVO");

                    b.Property<int>("_alturaG")
                        .HasColumnName("ALTURA_G");

                    b.Property<int>("_alturaP")
                        .HasColumnName("ALTURA_P");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<int>("_larguraG")
                        .HasColumnName("LARGURA_G");

                    b.Property<int>("_larguraP")
                        .HasColumnName("LARGURA_P");

                    b.Property<bool>("_thumbnail")
                        .HasColumnName("THUMBNAIL");

                    b.Property<string>("_titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_video")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("VIDEO")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.ToTable("NOTICIA_GRUPO");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Os", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<int>("_codigo_os")
                        .HasColumnName("CODIGO_OS");

                    b.Property<DateTime>("_data_criado")
                        .HasColumnName("DATA_CRIADO");

                    b.Property<DateTime>("_data_finalizado")
                        .HasColumnName("DATA_FINALIZADO");

                    b.Property<double>("_desc_moeda")
                        .HasColumnName("DESC_MOEDA");

                    b.Property<double>("_desc_percent")
                        .HasColumnName("DESC_PERCENT");

                    b.Property<string>("_fx")
                        .HasColumnName("FX");

                    b.Property<string>("_observacao")
                        .HasColumnName("OBSERVACAO");

                    b.Property<string>("_pb")
                        .HasColumnName("PB");

                    b.Property<string>("_pd")
                        .HasColumnName("PD");

                    b.Property<string>("_placa")
                        .HasColumnName("PLACA")
                        .HasColumnType("NVARCHAR(8)")
                        .HasMaxLength(8);

                    b.Property<string>("_pt")
                        .HasColumnName("PT");

                    b.Property<double>("_total")
                        .HasColumnName("TOTAL");

                    b.Property<double>("_total_pagar")
                        .HasColumnName("TOTAL_PAGAR");

                    b.Property<string>("_vt")
                        .HasColumnName("VT");

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.ToTable("OS");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.OsItem", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("_descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("_os_id")
                        .HasColumnName("OS_ID");

                    b.Property<double>("_preco")
                        .HasColumnName("PRECO");

                    b.Property<int>("_quantidade")
                        .HasColumnName("QUANTIDADE");

                    b.Property<double>("_total")
                        .HasColumnName("TOTAL");

                    b.HasKey("_id");

                    b.HasIndex("_os_id");

                    b.ToTable("OS_ITEM");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Perfil", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_titulo")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(30)")
                        .HasMaxLength(30);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.ToTable("PERFIL");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.PerfilItem", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<bool>("_delete")
                        .HasColumnName("DELETE");

                    b.Property<Guid>("_form_hash")
                        .HasColumnName("FORM_HASH");

                    b.Property<Guid>("_menu_hash")
                        .HasColumnName("MENU_HASH");

                    b.Property<Guid>("_perfil_id")
                        .HasColumnName("PERFIL_ID");

                    b.Property<bool>("_read")
                        .HasColumnName("READ");

                    b.Property<string>("_titulo_menu");

                    b.Property<bool>("_write")
                        .HasColumnName("WRITE");

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_form_hash");

                    b.HasIndex("_menu_hash");

                    b.HasIndex("_perfil_id");

                    b.ToTable("PERFIL_ITEM");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<string>("_bairro")
                        .HasColumnName("BAIRRO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("_celular")
                        .HasColumnName("CELULAR")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<string>("_cep")
                        .HasColumnName("CEP")
                        .HasColumnType("NVARCHAR(10)")
                        .HasMaxLength(10);

                    b.Property<string>("_cidade")
                        .HasColumnName("CIDADE")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_complemento")
                        .HasColumnName("COMPLEMENTO")
                        .HasColumnType("NVARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<string>("_cpf_cnpj")
                        .HasColumnName("CPF_CNPJ")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("_data_cadastro")
                        .HasColumnName("DATA_CADASTRO");

                    b.Property<DateTime>("_data_nascimento")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("_email")
                        .HasColumnName("EMAIL")
                        .HasColumnType("NVARCHAR(70)")
                        .HasMaxLength(70);

                    b.Property<string>("_endereco")
                        .HasColumnName("ENDERECO")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_estado")
                        .HasColumnName("ESTADO")
                        .HasColumnType("NVARCHAR(2)")
                        .HasMaxLength(2);

                    b.Property<string>("_imagem")
                        .HasColumnName("IMAGEM")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_numero")
                        .HasColumnName("NUMERO")
                        .HasColumnType("NVARCHAR(6)")
                        .HasMaxLength(6);

                    b.Property<string>("_sexo")
                        .HasColumnName("SEXO")
                        .HasColumnType("NVARCHAR(1)")
                        .HasMaxLength(1);

                    b.Property<string>("_telefone")
                        .HasColumnName("TELEFONE")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.ToTable("PERSON");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.PushCliente", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_ids_push")
                        .IsRequired()
                        .HasColumnName("IDS_PUSH")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_img_url")
                        .IsRequired()
                        .HasColumnName("IMG_URL")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_keys_push")
                        .IsRequired()
                        .HasColumnName("KEYS_PUSH")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_link_url")
                        .IsRequired()
                        .HasColumnName("LINK_URL")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_mensagem")
                        .HasColumnName("MENSAGEM")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("_titulo")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.ToTable("PUSH_CLIENTE");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_status_grupo_id")
                        .HasColumnName("STATUS_GRUPO_ID");

                    b.Property<string>("_titulo")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("_id");

                    b.HasIndex("_status_grupo_id");

                    b.ToTable("STATUS");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.StatusGrupo", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<Guid>("_formulario_id")
                        .HasColumnName("FORMULARIO_ID");

                    b.Property<string>("_titulo")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_formulario_id");

                    b.ToTable("STATUS_GRUPO");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool>("_ativo")
                        .HasColumnName("ATIVO");

                    b.Property<Guid>("_cod_cliente")
                        .HasColumnName("COD_CLIENTE");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("NVARCHAR(70)")
                        .HasMaxLength(70);

                    b.Property<string>("_nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("NVARCHAR(70)")
                        .HasMaxLength(70);

                    b.Property<Guid>("_perfil_id")
                        .HasColumnName("PERFIL_ID");

                    b.Property<string>("_senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("_usa_perfil")
                        .HasColumnName("USA_PERFIL");

                    b.Property<Guid>("_user_type_id")
                        .HasColumnName("USER_TYPE_ID");

                    b.HasKey("_id");

                    b.HasIndex("_cod_cliente");

                    b.HasIndex("_perfil_id");

                    b.HasIndex("_user_type_id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.UserType", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("_titulo")
                        .HasColumnName("TITULO")
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("_id");

                    b.ToTable("USER_TYPE");
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Contato", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Status", "_status")
                        .WithMany()
                        .HasForeignKey("_status_id")
                        .HasConstraintName("FK_CONTATO_ID_X_STATUS_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Fields", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Formulario", "_formulario")
                        .WithMany()
                        .HasForeignKey("_formulario_id")
                        .HasConstraintName("FK_FIELDS_FORMULARIO_ID_X_FORMULARIO_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.FieldsClient", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Cliente", "_cliente")
                        .WithMany()
                        .HasForeignKey("_cod_cliente")
                        .HasConstraintName("FK_FIELDS_CLIENTE_COD_CLIENTE_X_CLIENTE_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SylerBackend.Domain.Entities.Fields", "_fields")
                        .WithMany()
                        .HasForeignKey("_fields_id")
                        .HasConstraintName("FK_FIELDS_CLIENTE_ID_X_FIELDS_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Menu", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Formulario", "_formulario")
                        .WithMany()
                        .HasForeignKey("_formulario_id")
                        .HasConstraintName("FK_MENU_FORMULARIO_ID_X_FORMULARIO_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.MenuCliente", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Menu", "_menu")
                        .WithMany()
                        .HasForeignKey("_menu_id")
                        .HasConstraintName("FK_MENU_CLIENTE_MENU_ID_X_MENU_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Noticia", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.NoticiaGrupo", "_noticia_grupo")
                        .WithMany()
                        .HasForeignKey("_noticia_grupo_id")
                        .HasConstraintName("FK_NOTICIA_GRUPO_NOTICIA_ID_X_GRUPO_NOTICIA_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.OsItem", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Os", "_os")
                        .WithMany("_ositens")
                        .HasForeignKey("_os_id")
                        .HasConstraintName("FK_OS_ID_X_OS_ITEM_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.PerfilItem", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Perfil", "_perfil")
                        .WithMany("_perfil_itens")
                        .HasForeignKey("_perfil_id")
                        .HasConstraintName("FK_PERFIL_ID_X_PERFIL_ITEM_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.Status", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.StatusGrupo", "_status_grupo")
                        .WithMany("_status")
                        .HasForeignKey("_status_grupo_id")
                        .HasConstraintName("FK_STATUS_STATUS_GRUPO_ID_X_STATUS_STATUS_GRUPO_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SylerBackend.Domain.Entities.User", b =>
                {
                    b.HasOne("SylerBackend.Domain.Entities.Perfil", "_perfil")
                        .WithMany()
                        .HasForeignKey("_perfil_id")
                        .HasConstraintName("FK_USER_PERFIL_ID_X_PERFIL_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SylerBackend.Domain.Entities.UserType", "_user_type")
                        .WithMany()
                        .HasForeignKey("_user_type_id")
                        .HasConstraintName("FK_USER_USER_TYPE_ID_X_USER_TYPE_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
