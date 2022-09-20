using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class MenuClienteConfig : IEntityTypeConfiguration<MenuCliente>
    {
        public void Configure(EntityTypeBuilder<MenuCliente> entity)
        {
            entity.ToTable("MENU_CLIENTE");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._menu_id).IsUnique(false);
            entity.Property(s => s._menu_id).HasColumnName("MENU_ID");
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            entity.Property(s => s._url).HasColumnName("URL").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._icone).HasColumnName("ICONE").IsRequired();
            entity.Property(s => s._posicao).HasColumnName("POSICAO").IsRequired();
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();

            entity.HasOne(s => s._menu)
                .WithMany()
                .HasForeignKey(s => s._menu_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_MENU_CLIENTE_MENU_ID_X_MENU_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
