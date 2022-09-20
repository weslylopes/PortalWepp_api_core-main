using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Noticia
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public string _titulo { get; set; }

        public string _desc_curta { get; set; }

        public string _desc_longa { get; set; }

        public DateTime _data_inicial { get; set; }

        public DateTime _data_final { get; set; }

        public string _imagem { get; set; }

        public Guid _noticia_grupo_id { get; set; }

        public virtual NoticiaGrupo _noticia_grupo { get; set; }

        public Noticia()
        {
            this._data_inicial = new DateTime(2000, 01, 01);
            this._data_final = new DateTime(2100, 01, 01);
        }
    }
}
