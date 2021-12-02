using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class MaquinaEsterilizacion
    {
        public Int64 idMaquinaEsterilizacion { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public Int64 ciclosMantencion { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaMaquinaEsterilizacion
    {
        public BindingList<MaquinaEsterilizacion> List = new BindingList<MaquinaEsterilizacion>();
        public listaMaquinaEsterilizacion()
        {
        }
        public void Add(MaquinaEsterilizacion value)
        {
            this.List.Add(value);
        }
    }
}
