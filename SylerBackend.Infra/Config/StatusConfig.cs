using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.ToTable("STATUS");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._status_grupo_id).IsUnique(false);
            entity.Property(s => s._status_grupo_id).HasColumnName("STATUS_GRUPO_ID");

            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            
            entity.HasOne(s => s._status_grupo)
                .WithMany()
                .HasForeignKey(s => s._status_grupo_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_STATUS_ID_X_STATUS_GRUPO_STATUS_GRUPO_ID")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
