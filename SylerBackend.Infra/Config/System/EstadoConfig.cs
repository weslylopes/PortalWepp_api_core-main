using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config.System
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity.ToTable("ESTADO");

            entity.HasKey(t => t._id);
            entity.Property(c => c._id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(s => s._nome).HasColumnName("NOME").HasMaxLength(30).IsRequired().HasColumnType("NVARCHAR(30)");
            entity.Property(s => s._uf).HasColumnName("UF").HasMaxLength(2).IsRequired().HasColumnType("NVARCHAR(2)");
            entity.Property(s => s._regiao_id).HasColumnName("REGIAO_ID").IsRequired();

            entity.HasOne(s => s._regiao)
                .WithMany()
                .HasForeignKey(s => s._regiao_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_ESTADO_ID_X_REGIAO_ID")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
