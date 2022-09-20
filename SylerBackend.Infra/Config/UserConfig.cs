using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("USER");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");            
            entity.HasIndex(x => x._user_type_id).IsUnique(false);
            entity.Property(s => s._user_type_id).HasColumnName("USER_TYPE_ID");
            entity.HasIndex(x => x._perfil_id).IsUnique(false);
            entity.Property(s => s._perfil_id).HasColumnName("PERFIL_ID");

            entity.Property(s => s._nome).HasColumnName("NOME").IsRequired().HasMaxLength(70).HasColumnType("NVARCHAR(70)");
            entity.Property(s => s._email).HasColumnName("EMAIL").IsRequired().HasMaxLength(70).HasColumnType("NVARCHAR(70)");
            entity.Property(s => s._senha).HasColumnName("SENHA").IsRequired().HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();
            entity.Property(s => s._usa_perfil).HasColumnName("USA_PERFIL").IsRequired();

            entity.HasOne(s => s._user_type)
                .WithMany()
                .HasForeignKey(s => s._user_type_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_USER_USER_TYPE_ID_X_USER_TYPE_ID")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(s => s._perfil)
                .WithMany()
                .HasForeignKey(s => s._perfil_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_USER_PERFIL_ID_X_PERFIL_ID")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
