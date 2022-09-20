using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SylerBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Infra.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("CLIENTE");

            entity.HasKey(s => s._id);
            entity.Property(s => s._id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(s => s._codigo_aux).HasColumnName("CODIGO_AUX");
            entity.Property(s => s._fantasia).HasColumnName("FANTASIA").IsRequired();
            entity.Property(s => s._razao_social).HasColumnName("RAZAO_SOCIAL");
            entity.Property(s => s._cnpj).HasColumnName("CPF_CNPJ");
            entity.Property(s => s._endereco).HasColumnName("ENDERECO");
            entity.Property(s => s._bairro).HasColumnName("BAIRRO");
            entity.Property(s => s._cidade).HasColumnName("CIDADE");
            entity.Property(s => s._estado).HasColumnName("ESTADO");
            entity.Property(s => s._telefone).HasColumnName("TELEFONE");
            entity.Property(s => s._celular1).HasColumnName("CELULAR_1");
            entity.Property(s => s._celular2).HasColumnName("CELULAR_2");
            entity.Property(s => s._celular3).HasColumnName("CELULAR_3");
            entity.Property(s => s._ativo).HasColumnName("ATIVO").IsRequired();
            entity.Property(s => s._data_cadastro).HasColumnName("DATA_CADASTRO").IsRequired();
            entity.Property(s => s._dia_vencimento).HasColumnName("DIA_VENC");
            entity.Property(s => s._responsavel).HasColumnName("NOME_RESP");
            entity.Property(s => s._email).HasColumnName("EMAIL");
        }
    }
}
