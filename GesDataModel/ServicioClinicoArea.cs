using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class ServicioClinicoArea
    {
        public Int64 idServicioClinicoArea { get; set; }
        public Int64 idServicioClinico { get; set; }
        public string nombreServicioClinicoArea { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaServicioClinicoArea
    {
        public BindingList<ServicioClinicoArea> List = new BindingList<ServicioClinicoArea>();
        public listaServicioClinicoArea()
        {
        }
        public void Add(ServicioClinicoArea value)
        {
            this.List.Add(value);
        }
    }
}
