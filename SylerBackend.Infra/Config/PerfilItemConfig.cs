using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class PerfilItemConfig : IEntityTypeConfiguration<PerfilItem>
    {
        public void Configure(EntityTypeBuilder<PerfilItem> entity)
        {
            entity.ToTable("PERFIL_ITEM");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");
            entity.HasIndex(x => x._perfil_id).IsUnique(false);
            entity.Property(s => s._perfil_id).HasColumnName("PERFIL_ID");
            entity.HasIndex(x => x._menu_cliente_id).IsUnique(false);
            entity.Property(s => s._menu_cliente_id).HasColumnName("MENU_CLIENTE_ID");

            entity.Property(s => s._read).HasColumnName("READ").IsRequired();
            entity.Property(s => s._write).HasColumnName("WRITE").IsRequired();
            entity.Property(s => s._delete).HasColumnName("DELETE").IsRequired();

            entity.HasOne(s => s._menu_cliente)
                .WithMany()
                .HasForeignKey(s => s._menu_cliente_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_MENU_CLIENTE_ID_X_MENU_CLIENTE_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
