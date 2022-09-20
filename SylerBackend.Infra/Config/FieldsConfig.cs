using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class FieldsConfig : IEntityTypeConfiguration<Fields>
    {
        public void Configure(EntityTypeBuilder<Fields> entity)
        {
            entity.ToTable("FIELDS");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._formulario_id).IsUnique(false);
            entity.Property(s => s._formulario_id).HasColumnName("FORMULARIO_ID");
            entity.Property(s => s._nome).HasColumnName("NOME").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._type).HasColumnName("TYPE").HasMaxLength(20).HasColumnType("NVARCHAR(20)");
            entity.Property(s => s._size).HasColumnName("SIZE").HasMaxLength(10).HasColumnType("NVARCHAR(10)");

            entity.HasOne(s => s._formulario)
                .WithMany()
                .HasForeignKey(s => s._formulario_id)
                .HasConstraintName("FK_FIELDS_FORMULARIO_ID_X_FORMULARIO_ID")
                .HasPrincipalKey(x => x._id)
                .OnDelete(DeleteBehavior.Restrict);

            //entity.HasOne(x => x._formulario)
            //    .WithMany(x => x.Fields)
            //    .HasForeignKey(x => x._formulario_id)
            //    .HasPrincipalKey(x => x._id)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
