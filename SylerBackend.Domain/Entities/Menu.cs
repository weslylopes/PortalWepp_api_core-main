using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Menu
    {
        public Guid _id { get; set; }

        public string _titulo { get; set; }

        public string _icone { get; set; }

        public string _url { get; set; }

        public bool _ativo { get; set; }

        public Guid _formulario_id { get; set; }

        public virtual Formulario _formulario { get; set; }
    }
}
