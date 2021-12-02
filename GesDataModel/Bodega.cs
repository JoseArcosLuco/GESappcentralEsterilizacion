using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Bodega
    {
        public int idBodega { get; set; }
        public string nombreBodega { get; set; }
        public string codigoBodega { get; set; }
        public bool layout { get; set; }
        public string centroCosto { get; set; }
        public int nivel { get; set; }
        public int orden { get; set; }
        public int estado { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
    }

    public partial class listaBodega
    {
        public BindingList<Bodega> ListBodega = new BindingList<Bodega>();
        public listaBodega()
        {
        }
        public void Add(Bodega value)
        {
            this.ListBodega.Add(value);
        }
    }
}
