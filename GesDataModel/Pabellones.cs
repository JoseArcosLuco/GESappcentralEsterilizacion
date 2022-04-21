using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Pabellones
    {
        public Int32 idPabellon { get; set; }
        public Int32 idServicioClinico { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaPabellones
    {
        public BindingList<Pabellones> ListPabellones = new BindingList<Pabellones>();
        public listaPabellones()
        {
        }
        public void Add(Pabellones value)
        {
            this.ListPabellones.Add(value);
        }
    }
}
