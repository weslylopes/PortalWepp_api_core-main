using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Os
    {
        public Guid _id { get; set; }

        public Guid _cod_cliente { get; set; }

        public int _codigo_os { get; set; }

        public string _placa { get; set; }

        public string _pd { get; set; }

        public string _vt { get; set; }

        public string _pt { get; set; }

        public string _pb { get; set; }

        public string _fx { get; set; }

        public double _total { get; set; }

        public double _total_pagar { get; set; }

        public double _desc_percent { get; set; }

        public double _desc_moeda { get; set; }

        public DateTime _data_criado { get; set; }

        public DateTime _data_finalizado { get; set; }

        public string _observacao { get; set; }

        public virtual ICollection<OsItem> _ositens { get; set; }

        public Os()
        {
            this._data_criado = new DateTime(2000, 01, 01);
            this._data_finalizado = new DateTime(2100, 01, 01);
        }
    }
}
