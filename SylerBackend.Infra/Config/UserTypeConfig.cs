using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class UserTypeConfig : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> entity)
        {
            entity.ToTable("USER_TYPE");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            
            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
                        
        }
    }
}
