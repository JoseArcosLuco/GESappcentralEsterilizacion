using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Carro
    {
        public Int32 idCarro { get; set; }
        public string nombre { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaCarro
    {
        public BindingList<Carro> ListCarro = new BindingList<Carro>();
        public listaCarro()
        {
        }
        public void Add(Carro value)
        {
            this.ListCarro.Add(value);
        }
    }
}
