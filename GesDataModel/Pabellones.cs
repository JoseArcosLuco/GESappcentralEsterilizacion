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
        public Int64 idPabellon { get; set; }
        public Int64 idServicioClinicoArea { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaPabellones
    {
        public BindingList<Pabellones> List = new BindingList<Pabellones>();
        public listaPabellones()
        {
        }
        public void Add(Pabellones value)
        {
            this.List.Add(value);
        }
    }
}
