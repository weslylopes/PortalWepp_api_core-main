using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class FieldsClient
    {
        public Guid _id { get; set; }

        public string _titulo { get; set; }

        public bool _is_coluna_grid { get; set; }

        public string _grid_titulo { get; set; }

        public bool _is_Valida { get; set; }

        public Guid _fields_id { get; set; }

        public virtual Fields _fields { get; set; }

        public Guid _cod_cliente { get; set; }

        public virtual Cliente _cliente { get; set; }

    }
}
