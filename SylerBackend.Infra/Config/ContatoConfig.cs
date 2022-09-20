using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> entity)
        {
            entity.ToTable("CONTATO");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._status_id).IsUnique(false);
            entity.Property(s => s._status_id).HasColumnName("STATUS_ID");
            entity.HasIndex(x => x._person_id).IsUnique(false);
            entity.Property(s => s._person_id).HasColumnName("PERSON_ID");
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");
            entity.HasIndex(x => x._user_id_create).IsUnique(false);
            entity.Property(s => s._user_id_create).HasColumnName("USER_ID_CREATE");

            entity.Property(s => s._ativo).HasColumnName("ATIVO");
            entity.Property(s => s._comentario).HasColumnName("COMENTARIO").HasMaxLength(500).HasColumnType("NVARCHAR(500)");
            entity.Property(s => s._data_cadastro).HasColumnName("DATA_CADASTRO");
            entity.Property(s => s._data_nascimento).HasColumnName("DATA_NASCIMENTO");
            entity.Property(s => s._data_ultimo_contato).HasColumnName("DATA_ULTIMO_CONTATO");
            entity.Property(s => s._email).HasColumnName("EMAIL").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._cidade).HasColumnName("CIDADE").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._nome).HasColumnName("NOME").HasMaxLength(70).HasColumnType("NVARCHAR(70)");
            entity.Property(s => s._cpf).HasColumnName("CPF").HasMaxLength(15).HasColumnType("NVARCHAR(15)");
            entity.Property(s => s._telefone).HasColumnName("TELEFONE").HasMaxLength(20).HasColumnType("NVARCHAR(20)");
            entity.Property(s => s._whatsapp).HasColumnName("WHATSAPP").HasMaxLength(20).HasColumnType("NVARCHAR(20)");

            entity.HasOne(s => s._status)
                .WithMany()
                .HasForeignKey(s => s._status_id)
                .HasPrincipalKey(s => s._id)
                .HasConstraintName("FK_CONTATO_ID_X_STATUS_ID")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
