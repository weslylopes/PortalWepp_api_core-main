using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Status
    {
        public Guid _id { get; set; }

        public string _titulo { get; set; }

        public Guid _status_grupo_id { get; set; }

        public virtual StatusGrupo _status_grupo { get; set; }
    }
}
