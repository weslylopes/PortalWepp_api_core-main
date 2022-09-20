using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> entity)
        {
            entity.ToTable("MENU");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._formulario_id).IsUnique(false);
            entity.Property(s => s._formulario_id).HasColumnName("FORMULARIO_ID");

            entity.Property(s => s._titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._icone).HasColumnName("GRID_TITULO").IsRequired().HasMaxLength(30).HasColumnType("NVARCHAR(30)");
            entity.Property(s => s._url).HasColumnName("URL").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();

            entity.HasOne(s => s._formulario)
                .WithMany()
                .HasForeignKey(s => s._formulario_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_MENU_FORMULARIO_ID_X_FORMULARIO_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
