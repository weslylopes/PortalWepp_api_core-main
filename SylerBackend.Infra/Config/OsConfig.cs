using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class OsConfig : IEntityTypeConfiguration<Os>
    {
        public void Configure(EntityTypeBuilder<Os> entity)
        {
            entity.ToTable("OS");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._codigo_os).HasColumnName("CODIGO_OS");
            entity.Property(s => s._placa).HasColumnName("PLACA").HasMaxLength(8).HasColumnType("NVARCHAR(8)");
            entity.Property(s => s._pd).HasColumnName("PD");
            entity.Property(s => s._vt).HasColumnName("VT");
            entity.Property(s => s._pt).HasColumnName("PT");
            entity.Property(s => s._pb).HasColumnName("PB");
            entity.Property(s => s._fx).HasColumnName("FX");
            entity.Property(s => s._total).HasColumnName("TOTAL");
            entity.Property(s => s._total_pagar).HasColumnName("TOTAL_PAGAR");
            entity.Property(s => s._desc_percent).HasColumnName("DESC_PERCENT");
            entity.Property(s => s._desc_moeda).HasColumnName("DESC_MOEDA");
            entity.Property(s => s._data_criado).HasColumnName("DATA_CRIADO").IsRequired();
            entity.Property(s => s._data_finalizado).HasColumnName("DATA_FINALIZADO").IsRequired();
            entity.Property(s => s._observacao).HasColumnName("OBSERVACAO");

            entity.HasMany(t => t._ositens)
                .WithOne(p => p._os)
                .HasForeignKey(p => p._os_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_OS_ID_X_OS_ITEM_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
