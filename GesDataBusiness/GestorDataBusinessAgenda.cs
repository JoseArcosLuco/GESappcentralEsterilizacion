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


        public listaAgenda ListarAgenda(int id)
        {
            listaAgenda lb = new listaAgenda();
            try
            {
                GestorDataAccessAgenda ga = new GestorDataAccessAgenda();
                lb = ga.Listar(id);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta CambiarEstadoAgenda(Int32 id, Int16 estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessAgenda gb = new GestorDataAccessAgenda();
                r = gb.CambioEstado(id, estado);
            }
            catch (Exception ex)
            {
                r.estado = 1;
                r.descripcion = "Cambio de estado fallo, error:" + ex.Message.ToString();
            }
            return r;
        }
    }
}
