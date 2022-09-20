using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config.System
{
    public class MunicipioConfig : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> entity)
        {
            entity.ToTable("MUNICIPIO");

            entity.HasKey(t => t._id);
            entity.Property(c => c._id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(s => s._nome).HasColumnName("NOME").HasMaxLength(30).IsRequired().HasColumnType("NVARCHAR(30)");
            entity.Property(s => s._estado_id).HasColumnName("ESTADO_ID").IsRequired();

            entity.HasOne(s => s._estado)
                .WithMany()
                .HasForeignKey(s => s._estado_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_MUNICIPIO_ID_X_ESTADO_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
