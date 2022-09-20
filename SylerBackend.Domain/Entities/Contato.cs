using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Contato
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public Guid _person_id { get; set; }

        public string _nome { get; set; }

        public string _cpf { get; set; }

        public DateTime _data_nascimento { get; set; }

        public string _telefone { get; set; }

        public string _whatsapp { get; set; }

        public string _email { get; set; }

        public string _comentario { get; set; }

        public string _cidade { get; set; }

        public bool _ativo { get; set; }

        public DateTime _data_cadastro { get; set; }

        public Guid _user_id_create { get; set; }

        public DateTime _data_ultimo_contato { get; set; }

        public Guid _status_id { get; set; }

        public Status _status { get; set; }

    }
}
