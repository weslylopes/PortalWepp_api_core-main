using SylerBackend.Domain.Entities;
using System;

namespace SylerBackend.Domain.ResponseModel
{
    public class UserResponseModel
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _nome { get; set; }

        public bool _usa_perfil { get; set; }

        public UserType _user_type { get; set; }

        public Perfil _perfil { get; set; }
    }
}
