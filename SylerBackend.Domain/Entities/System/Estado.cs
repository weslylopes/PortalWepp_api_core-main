using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities.System
{
    public class Estado
    {
        public int _id { get; set; }
        public string _nome { get; set; }
        public string _uf { get; set; }
        public int _regiao_id { get; set; }
        public Regiao _regiao { get; set; }
    }
}
