using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities.System
{
    public class Municipio
    {
        public int _id { get; set; }
        public string _nome { get; set; }
        public int _estado_id { get; set; }
        public Estado _estado { get; set; }
    }
}
