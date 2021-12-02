using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Articulo
    {
        public Articulo() {

        }
        public Int64 idArticulo { get; set; }
        public int idTipoArticulo { get; set; }
        public int idClasificacion { get; set; }
        public string nombreArticulo { get; set; }
        public string nombreComercial { get; set; }
        public string codigoArticulo { get; set; }
        public string codigoBarra { get; set; }
        public string codigoExterno { get; set; }
        public decimal ancho { get; set; }
        public decimal alto { get; set; }
        public decimal profundidad { get; set; }
        public decimal defaultStockMinimo { get; set; }
        public decimal defaultStockMaximo { get; set; }
        public decimal defaultStockCritico { get; set; }
        public Int64 defaultCosto { get; set; }
        public Int64 defaultPrecio { get; set; }
        public Int64 defaultRotacionMantencion { get; set; }
        public bool vencimiento { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaArticulo
    {
        public BindingList<Articulo> ListArticulo = new BindingList<Articulo>();
        public listaArticulo()
        {
        }
        public void Add(Articulo value)
        {
            this.ListArticulo.Add(value);
        }
    }
}
