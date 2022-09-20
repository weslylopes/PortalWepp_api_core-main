using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class PerfilItem
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }
        
        public bool _read { get; set; }

        public bool _write { get; set; }

        public bool _delete { get; set; }

        public Guid _menu_cliente_id { get; set; }

        public virtual MenuCliente _menu_cliente { get; set; }

        public Guid _perfil_id { get; set; }

        public virtual Perfil _perfil { get; set; }
        
    }
}
