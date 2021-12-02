using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class KitArticulo
    {
        public Int32 idKitArticulo { get; set; }
        public Int32 idKit { get; set; }
        public Int32 idArticulo { get; set; }
        public Int32 cantidadArticulo { get; set; }
        public string nombre { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaKitArticulo
    {
        public BindingList<KitArticulo> ListKitArticulo = new BindingList<KitArticulo>();
        public listaKitArticulo()
        {
        }
        public void Add(KitArticulo value)
        {
            this.ListKitArticulo.Add(value);
        }
    }
}
