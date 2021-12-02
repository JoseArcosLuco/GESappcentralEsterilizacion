using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class ServicioClinico
    {
        public Int64 idServicioClinico { get; set; }
        public string codigoServicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaServicioClinico
    {
        public BindingList<ServicioClinico> List = new BindingList<ServicioClinico>();
        public listaServicioClinico()
        {
        }
        public void Add(ServicioClinico value)
        {
            this.List.Add(value);
        }
    }
}
