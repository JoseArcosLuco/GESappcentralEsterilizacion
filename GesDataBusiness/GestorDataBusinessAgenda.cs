using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessAgenda
    {
        public Respuesta Grabar(Agenda b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessAgenda ga = new GestorDataAccessAgenda();
                r = ga.Grabar(b);
            }
            catch (Exception error)
            {
                r.estado = 0;
                r.descripcion = error.Message;
                //throw;
            }
            return r;
        }
    }
}
