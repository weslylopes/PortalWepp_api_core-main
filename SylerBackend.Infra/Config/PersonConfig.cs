using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("PERSON");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.HasIndex(x => x._cod_cliente).IsUnique(false);
            entity.Property(s => s._cod_cliente).HasColumnName("COD_CLIENTE");

            entity.Property(s => s._nome).HasColumnName("NOME").IsRequired().HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._cpf_cnpj).HasColumnName("CPF_CNPJ").HasMaxLength(20).HasColumnType("NVARCHAR(20)");
            entity.Property(s => s._data_nascimento).HasColumnName("DATA_NASCIMENTO");
            entity.Property(s => s._sexo).HasColumnName("SEXO").HasMaxLength(1).HasColumnType("NVARCHAR(1)");
            entity.Property(s => s._email).HasColumnName("EMAIL").HasMaxLength(70).HasColumnType("NVARCHAR(70)");
            entity.Property(s => s._telefone).HasColumnName("TELEFONE").HasMaxLength(20).HasColumnType("NVARCHAR(20)");
            entity.Property(s => s._celular).HasColumnName("CELULAR").HasMaxLength(20).HasColumnType("NVARCHAR(20)");
            entity.Property(s => s._cep).HasColumnName("CEP").HasMaxLength(10).HasColumnType("NVARCHAR(10)");
            entity.Property(s => s._endereco).HasColumnName("ENDERECO").HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._numero).HasColumnName("NUMERO").HasMaxLength(6).HasColumnType("NVARCHAR(6)");
            entity.Property(s => s._bairro).HasColumnName("BAIRRO").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._cidade).HasColumnName("CIDADE").HasMaxLength(50).HasColumnType("NVARCHAR(50)");
            entity.Property(s => s._estado).HasColumnName("ESTADO").HasMaxLength(2).HasColumnType("NVARCHAR(2)");
            entity.Property(s => s._complemento).HasColumnName("COMPLEMENTO").HasMaxLength(200).HasColumnType("NVARCHAR(200)");
            entity.Property(s => s._imagem).HasColumnName("IMAGEM").HasMaxLength(100).HasColumnType("NVARCHAR(100)");
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();
            entity.Property(s => s._data_cadastro).HasColumnName("DATA_CADASTRO").IsRequired();
            entity.HasIndex(x => x._user_create).IsUnique(false);
            entity.Property(s => s._user_create).HasColumnName("USER_CREATE").HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
