using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> entity)
        {
            entity.ToTable("PERFIL");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            
            entity.HasMany(t => t._perfil_itens)
                .WithOne(p => p._perfil)
                .HasForeignKey(p => p._perfil_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_PERFIL_ID_X_PERFIL_ITEM_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
