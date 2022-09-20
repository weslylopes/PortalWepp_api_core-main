using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class FieldsClientConfig : IEntityTypeConfiguration<FieldsClient>
    {
        public void Configure(EntityTypeBuilder<FieldsClient> entity)
        {
            entity.ToTable("FIELDS_CLIENTE");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");
            entity.HasIndex(x => x._fields_id).IsUnique(false);
            entity.Property(s => s._fields_id).HasColumnName("FIELD_ID");

            entity.Property(s => s._titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._grid_titulo).HasColumnName("GRID_TITULO").HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            entity.Property(s => s._is_coluna_grid).HasColumnName("IS_COLUNA_GRID").IsRequired();
            entity.Property(s => s._is_Valida).HasColumnName("IS_VALIDA").IsRequired();

            entity.HasOne(s => s._fields)
                .WithMany()
                .HasForeignKey(s => s._fields_id)
                .HasForeignKey(x => x._fields_id)
                .HasConstraintName("FK_FIELDS_CLIENTE_ID_X_FIELDS_ID")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s._cliente)
                .WithMany()
                .HasForeignKey(s => s._cod_cliente)
                .HasPrincipalKey(x => x._id)
                .HasConstraintName("FK_FIELDS_CLIENTE_COD_CLIENTE_X_CLIENTE_ID")
                .OnDelete(DeleteBehavior.Restrict);            

        }
    }
}
