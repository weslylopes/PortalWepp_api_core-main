using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class OsItem
    {
        public Guid _id { get; set; }

        public int _quantidade { get; set; }

        public string _descricao { get; set; }

        public double _preco { get; set; }

        public double _total { get; set; }

        public Guid _os_id { get; set; }

        public virtual Os _os { get; set; }
    }
}
