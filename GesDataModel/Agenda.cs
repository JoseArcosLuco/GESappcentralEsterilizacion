using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ges.data.model
{
    public class Agenda
    {
        public int idAgenda { get; set; }
        public int idUsuario { get; set; }
        public int idUsuarioProfesional { get; set; }
        public int idUsuarioPaciente { get; set; }
        public int idAgendaConfiguracion { get; set; }
        public int idPabellon { get; set; }
        public int idArea { get; set; }
        public string asunto { get; set; }
        public string descripcion { get; set; }
        public string fechaAgenda { get; set; }
        public string horaAgenda { get; set; }
        public string fechaReg { get; set; }
        public string fechaAct { get; set; }
        public int estado { get; set; }
    }
    public partial class listaAgenda
    {
        public BindingList<Agenda> ListAgenda = new BindingList<Agenda>();
        public listaAgenda()
        {
        }
        public void Add(Agenda value)
        {
            this.ListAgenda.Add(value);
        }
    }
}
