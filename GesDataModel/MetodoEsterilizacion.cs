using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class MetodoEsterilizacion
    {
        public Int64 idMetodoEsterilizacion { get; set; }
        public Int64 idMaquinaEsterilizacion { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaMetodoEsterilizacion
    {
        public BindingList<MetodoEsterilizacion> List = new BindingList<MetodoEsterilizacion>();
        public listaMetodoEsterilizacion()
        {
        }
        public void Add(MetodoEsterilizacion value)
        {
            this.List.Add(value);
        }
    }
}
