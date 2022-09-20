using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Fields
    {
        public Guid _id { get; set; }

        public Guid _formulario_id { get; set; }

        public string _nome { get; set; }

        public string _type { get; set; }

        public string _size { get; set; }

        public Formulario _formulario { get; set; }

    }
}
