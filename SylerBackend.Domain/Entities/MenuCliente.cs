using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class MenuCliente
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _titulo { get; set; }

        public string _url { get; set; }

        public string _icone { get; set; }

        public int _posicao { get; set; }

        public bool _ativo { get; set; }

        public Guid _menu_id { get; set; }

        public virtual Menu _menu { get; set; }
    }
}
