using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class MaquinaMantencion
    {
        public Int64 idMaquinaMantencion { get; set; }
        public Int64 idMaquinaEsterilizacion { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string fechaMantencion { get; set; }
        public string empresaMantencion { get; set; }
        public string tecnicoMantencion { get; set; }
        public string emailTecnico { get; set; }
        public string telefonoTecnico { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaMaquinaMantencion
    {
        public BindingList<MaquinaMantencion> List = new BindingList<MaquinaMantencion>();
        public listaMaquinaMantencion()
        {
        }
        public void Add(MaquinaMantencion value)
        {
            this.List.Add(value);
        }
    }
}
