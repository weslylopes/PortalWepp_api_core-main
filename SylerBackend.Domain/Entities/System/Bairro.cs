using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities.System
{
    public class Bairro
    {
        public int _id { get; set; }
        public string _nome { get; set; }
        public int _municipio_id { get; set; }
        public Municipio _municipio { get; set; }
    }
}
