using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Cliente
    {
        public Guid _id { get; set; }

        public int _codigo_aux { get; set; }

        public string _fantasia { get; set; }

        public string _razao_social { get; set; }

        public string _cnpj { get; set; }

        public string _endereco { get; set; }

        public string _bairro { get; set; }

        public string _cidade { get; set; }

        public string _estado { get; set; }

        public string _telefone { get; set; }

        public string _celular1 { get; set; }

        public string _celular2 { get; set; }

        public string _celular3 { get; set; }

        public bool _ativo { get; set; }

        public DateTime _data_cadastro { get; set; }

        public string _dia_vencimento { get; set; }

        public string _responsavel { get; set; }

        public string _email { get; set; }

        public Cliente()
        {
            //this._id = Guid.NewGuid();
            this._data_cadastro = new DateTime().Date;
        }
    }
}
