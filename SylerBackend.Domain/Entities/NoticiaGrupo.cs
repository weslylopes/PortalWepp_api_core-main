using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class NoticiaGrupo
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _titulo { get; set; }

        public int _larguraG { get; set; }

        public int _alturaG { get; set; }

        public int _larguraP { get; set; }

        public int _alturaP { get; set; }

        public bool _thumbnail { get; set; }

        public bool _video { get; set; }

        public bool Ativo { get; set; }

        public NoticiaGrupo()
        {
            Ativo = true;
        }
    }
}
