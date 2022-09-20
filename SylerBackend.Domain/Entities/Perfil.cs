using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Perfil
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _titulo { get; set; }

        public ICollection<PerfilItem> _perfil_itens { get; set; }
    }
}
