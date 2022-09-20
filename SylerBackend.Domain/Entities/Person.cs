using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Person
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _nome { get; set; }

        public string _cpf_cnpj { get; set; }

        public DateTime _data_nascimento { get; set; }

        public string _sexo { get; set; }

        public string _email { get; set; }

        public string _telefone { get; set; }

        public string _celular { get; set; }

        public string _cep { get; set; }

        public string _endereco { get; set; }

        public string _numero { get; set; }

        public string _bairro { get; set; }

        public string _cidade { get; set; }

        public string _estado { get; set; }

        public string _complemento { get; set; }

        public string _imagem { get; set; }

        public DateTime _data_cadastro { get; set; }

        public Guid _user_create { get; set; }

        public bool _ativo { get; set; }

    }
}
