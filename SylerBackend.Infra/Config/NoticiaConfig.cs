using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class NoticiaConfig : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> entity)
        {
            entity.ToTable("NOTICIA");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._noticia_grupo_id).IsUnique(false);
            entity.Property(s => s._noticia_grupo_id).HasColumnName("NOTICIA_GRUPO_ID"); entity.HasIndex(x => x._noticia_grupo_id).IsUnique(false);
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._desc_curta).HasColumnName("DESC_CURTA").IsRequired().HasMaxLength(200).HasColumnType("NVARCHAR(200)");
            entity.Property(s => s._desc_longa).HasColumnName("DESC_LONG").IsRequired().HasMaxLength(2000).HasColumnType("NVARCHAR(2000)");
            entity.Property(s => s._data_inicial).HasColumnName("DATA_INICIAL").IsRequired();
            entity.Property(s => s._data_final).HasColumnName("DATA_FINAL").IsRequired();
            entity.Property(s => s._imagem).HasColumnName("IMAGEM").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");

            entity.HasOne(s => s._noticia_grupo)
                .WithMany()
                .HasForeignKey(s => s._noticia_grupo_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_NOTICIA_GRUPO_NOTICIA_ID_X_GRUPO_NOTICIA_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
