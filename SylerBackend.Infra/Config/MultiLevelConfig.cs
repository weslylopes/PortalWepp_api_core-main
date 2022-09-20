using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class MultiLevelConfig : IEntityTypeConfiguration<MultiLevel>
    {
        public void Configure(EntityTypeBuilder<MultiLevel> entity)
        {
            entity.ToTable("MULTI_LEVEL");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").IsRequired().ValueGeneratedNever();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");
            entity.HasIndex(x => x._user_id).IsUnique(false);
            entity.Property(s => s._user_id).HasColumnName("USER_ID");
            entity.HasIndex(x => x._type_level_id).IsUnique(false);
            entity.Property(s => s._type_level_id).HasColumnName("TYPE_LEVEL_ID");

            entity.Property(s => s._fk_id).HasColumnName("FK_ID").IsRequired(false);
            entity.Property(s => s._id_pai).HasColumnName("ID_PAI").IsRequired(false);
            entity.Property(s => s._nivel).HasColumnName("NIVEL").IsRequired(false);

            //entity.HasOne(s => s._person)
            //    .WithMany()
            //    .HasForeignKey(s => s._person_id)
            //    .HasPrincipalKey(s => s._id)
            //    .HasConstraintName("FK_MULTI_LEVEL_ID_X_PERSON_ID")
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
