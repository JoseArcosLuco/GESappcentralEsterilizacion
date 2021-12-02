using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessKit
    {
        public Respuesta Grabar(Kit b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKit ga = new GestorDataAccessKit();
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

        public listaKit ListarKit()
        {
            listaKit lb = new listaKit();
            try
            {

                GestorDataAccessKit ga = new GestorDataAccessKit();
                lb = ga.Listar();
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta EliminarKit(Int16 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKit gb = new GestorDataAccessKit();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1; r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoKit(Int16 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKit gb = new GestorDataAccessKit();
                r = gb.CambioEstado(id, estado);
            }
            catch (Exception ex)
            {
                r.estado = 1; r.descripcion = "La activacion fallo error:" + ex.Message.ToString();
            }
            return r;
        }
    }
}
