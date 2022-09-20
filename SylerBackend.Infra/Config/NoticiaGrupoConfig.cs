using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class NoticiaGrupoConfig : IEntityTypeConfiguration<NoticiaGrupo>
    {
        public void Configure(EntityTypeBuilder<NoticiaGrupo> entity)
        {
            entity.ToTable("NOTICIA_GRUPO");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._larguraG).HasColumnName("LARGURA_G").IsRequired();
            entity.Property(s => s._alturaG).HasColumnName("ALTURA_G").IsRequired();
            entity.Property(s => s._larguraP).HasColumnName("LARGURA_P").IsRequired();
            entity.Property(s => s._alturaP).HasColumnName("ALTURA_P").IsRequired();
            entity.Property(s => s._thumbnail).HasColumnName("THUMBNAIL").IsRequired();
            entity.Property(s => s._video).HasColumnName("VIDEO").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s.Ativo).HasColumnName("ATIVO").IsRequired();

        }
    }
}
