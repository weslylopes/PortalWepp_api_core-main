using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class TypeLevelConfig : IEntityTypeConfiguration<TypeLevel>
    {
        public void Configure(EntityTypeBuilder<TypeLevel> entity)
        {
            entity.ToTable("TYPE_LEVEL");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();

            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(50).HasColumnType("NVARCHAR(50)");

        }
    }
}
