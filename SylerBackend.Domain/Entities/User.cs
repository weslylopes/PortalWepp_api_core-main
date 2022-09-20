using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class User
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _nome { get; set; }

        public string _email { get; set; }
        
        public string _senha { get; set; }

        public bool _ativo { get; set; }

        public bool _usa_perfil { get; set; }

        public Guid _user_type_id { get; set; }

        public UserType _user_type { get; set; }

        public Guid _perfil_id { get; set; }

        public Perfil _perfil { get; set; }

    }
}
