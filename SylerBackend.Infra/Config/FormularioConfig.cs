using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class FormularioConfig : IEntityTypeConfiguration<Formulario>
    {
        public void Configure(EntityTypeBuilder<Formulario> entity)
        {
            entity.ToTable("FORMULARIO");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(s => s._nome).HasColumnName("NOME").IsRequired();
            entity.Property(s => s._url).HasColumnName("URL").IsRequired();
            entity.Property(s => s._objetivo).HasColumnName("OBJETIVO").IsRequired();
                        
        }
    }
}
