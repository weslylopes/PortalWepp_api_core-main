using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class PushClienteConfig : IEntityTypeConfiguration<PushCliente>
    {
        public void Configure(EntityTypeBuilder<PushCliente> entity)
        {
            entity.ToTable("PUSH_CLIENTE");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._ids_push).HasColumnName("IDS_PUSH").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._keys_push).HasColumnName("KEYS_PUSH").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._titulo).HasColumnName("TITULO").HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._mensagem).HasColumnName("MENSAGEM").HasMaxLength(500).HasColumnType("NVARCHAR(500)");
            entity.Property(s => s._link_url).HasColumnName("LINK_URL").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._img_url).HasColumnName("IMG_URL").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();
            
        }
    }
}
