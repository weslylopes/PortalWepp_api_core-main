using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config.System
{
    public class RegiaoConfig : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> entity)
        {
            entity.ToTable("REGIAO");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").UseSqlServerIdentityColumn().IsRequired();
            entity.Property(s => s._nome).HasColumnName("NOME").HasMaxLength(30).IsRequired().HasColumnType("NVARCHAR(30)");
            
        }
    }
}
