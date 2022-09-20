using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class MultiLevel
    {
        public int _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _fk_id { get; set; }

        public Guid _user_id { get; set; }

        public int? _id_pai { get; set; }

        public int? _nivel { get; set; }

        public Guid _type_level_id { get; set; }

        //public virtual Person _person { get; set; }
    }
}
