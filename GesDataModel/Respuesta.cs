using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ges.data.model
{
    public class Respuesta
    {
        public Respuesta()
        {
            this.estado = 1;
            this.descripcion = "";
        }
        public int estado { get; set; }
        public string descripcion { get; set; }
    }
}
