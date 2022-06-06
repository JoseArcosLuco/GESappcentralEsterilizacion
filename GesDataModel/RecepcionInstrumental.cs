using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class RecepcionInstrumental
    {
        public Int64 idForm { get; set; }
        public Int64 idUsuario { get; set; }
        public Int64 idStock { get; set; }
        public Int64 idRecepcionSalidaPabellon { get; set; }
        public Int64 idServicioClinico { get; set; }
        public Int64 idServicioClinicoArea { get; set; }
        public Int64 idPabellon { get; set; }
        public string nombreFormulario { get; set; }
        public string nombreArticulo { get; set; }
        public string nombreBodega { get; set; }
        public Int64 cantidadRotacion { get; set; }
        public string nombreUsuario { get; set; }
        public string puesto { get; set; }
        public string codigoTrazable { get; set; }
        public string nombrePaciente { get; set; }
        public string rutPaciente { get; set; }

        public byte materialLimpio { get; set; }
        public byte materialOrganicoVisible { get; set; }
        public string desarmePiezas { get; set; }
        public int cantMaterialALavar { get; set; }
        public string observacion { get; set; }

        public string fechaMantencion { get; set; }
        public string fechaReg { get; set; }
        public string horaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
        public int estadoCheck { get; set; }
    }
    public partial class listaRecepcionInstrumental
    {
        public BindingList<RecepcionInstrumental> List = new BindingList<RecepcionInstrumental>();
        public listaRecepcionInstrumental()
        {
        }
        public void Add(RecepcionInstrumental value)
        {
            this.List.Add(value);
        }
    }
}
