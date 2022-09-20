using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config.System
{
    public class BairroConfig : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> entity)
        {
            entity.ToTable("BAIRRO");

            entity.HasKey(t => t._id);
            entity.Property(c => c._id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(s => s._nome).HasColumnName("NOME").HasMaxLength(70).IsRequired().HasColumnType("NVARCHAR(70)");
            entity.Property(s => s._municipio_id).HasColumnName("MUNICIPIO_ID").IsRequired();

            entity.HasOne(s => s._municipio)
                .WithMany()
                .HasForeignKey(s => s._municipio_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_BAIRRO_ID_X_MUNICIPIO_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
