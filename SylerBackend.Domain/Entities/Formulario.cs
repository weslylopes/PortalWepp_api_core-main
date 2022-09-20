using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.Entities
{
    public class Formulario
    {
        public Guid _id { get; set; }

        public string _nome { get; set; }

        public string _url { get; set; }

        public string _objetivo { get; set; }

        //public Guid _read_hash { get; set; }

        //public Guid _write_read { get; set; }

        //public Guid _delete_hash { get; set; }

        public Formulario()
        {
            //this._read_hash = Guid.NewGuid();
            //this._write_read = Guid.NewGuid();
            //this._delete_hash = Guid.NewGuid();
        }

    }
}
