using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class OsItemConfig : IEntityTypeConfiguration<OsItem>
    {
        public void Configure(EntityTypeBuilder<OsItem> entity)
        {
            entity.ToTable("OS_ITEM");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            entity.HasIndex(x => x._os_id).IsUnique(false);
            entity.Property(s => s._os_id).HasColumnName("OS_ID");//.IsRequired();

            entity.Property(s => s._quantidade).HasColumnName("QUANTIDADE").IsRequired();
            entity.Property(s => s._descricao).HasColumnName("DESCRICAO").HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._preco).HasColumnName("PRECO").IsRequired();
            entity.Property(s => s._total).HasColumnName("TOTAL").IsRequired();

            //entity.HasOne(s => s._os)
            //    .WithMany()
            //    .HasForeignKey(s => s._os_id)
            //    .HasConstraintName("FK_OS_ITEM_ID_X_OS_ID")
            //    .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
