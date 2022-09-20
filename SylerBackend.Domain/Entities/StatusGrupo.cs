using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class StatusGrupo
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public Guid _formulario_id { get; set; }

        public string _titulo { get; set; }

        public virtual ICollection<Status> _status { get; set; }
    }
}
