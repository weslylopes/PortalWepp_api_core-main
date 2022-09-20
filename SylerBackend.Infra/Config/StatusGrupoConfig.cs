using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class StatusGrupoConfig : IEntityTypeConfiguration<StatusGrupo>
    {
        public void Configure(EntityTypeBuilder<StatusGrupo> entity)
        {
            entity.ToTable("STATUS_GRUPO");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");
            entity.HasIndex(x => x._formulario_id).IsUnique(false);
            entity.Property(s => s._formulario_id).HasColumnName("FORMULARIO_ID");
            
            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(50).HasColumnType("NVARCHAR(50)");

            entity.HasMany(t => t._status)
                .WithOne(p => p._status_grupo)
                .HasForeignKey(p => p._status_grupo_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_STATUS_STATUS_GRUPO_ID_X_STATUS_STATUS_GRUPO_ID")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
