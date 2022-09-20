using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class PushCliente
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _ids_push { get; set; }

        public string _keys_push { get; set; }

        public string _titulo { get; set; }

        public string _mensagem { get; set; }

        public string _link_url { get; set; }

        public string _img_url { get; set; }

        public bool _ativo { get; set; }
    }
}
