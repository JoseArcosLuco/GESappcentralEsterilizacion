using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class RecepcionLavado
    {
        public Int64 idForm { get; set; }
        public Int64 idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public Int64 idRecepcionSalidaPabellon { get; set; }
        public Int64 idServicioClinico { get; set; }
        public Int64 idServicioClinicoArea { get; set; }
        public Int64 idPabellon { get; set; }
        public string puesto { get; set; }
        public string codigoTrazable { get; set; }
        public string nombreFormulario { get; set; }

        public string materialALavar { get; set; }
        public string cantMaterialALavar { get; set; }
        public string chorroAgua { get; set; }
        public string desarmePiezas { get; set; }
        public string metodoLavado { get; set; }
        public string cargaDePiezas { get; set; }
        public string numeroCarga { get; set; }
        public string observacion { get; set; }
        public string responsableDescarga { get; set; }

        public string fechaReg { get; set; }
        public string horaReg { get; set; }
        public string fechaAct { get; set; }
        public string fechaMantencion { get; set; }

        public Int64 idStock { get; set; }
        public string nombreArticulo { get; set; }
        public Int64 cantidadRotacion { get; set; }
        public string nombreBodega { get; set; }

        public int estado { get; set; }
        public int estadoCheck { get; set; }
    }
    public partial class listaRecepcionLavado
    {
        public BindingList<RecepcionLavado> List = new BindingList<RecepcionLavado>();
        public listaRecepcionLavado()
        {
        }
        public void Add(RecepcionLavado value)
        {
            this.List.Add(value);
        }
    }
}
