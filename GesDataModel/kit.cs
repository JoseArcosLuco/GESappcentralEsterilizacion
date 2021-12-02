using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Kit
    {
        public Int32 idKit  { get; set; }
        public string nombre { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }

    }
    public partial class listaKit
    {
        public BindingList<Kit> ListKit = new BindingList<Kit>();
        public listaKit()
        {
        }
        public void Add(Kit value)
        {
            this.ListKit.Add(value);
        }
    }
}
