using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessMetodoEsterilizacion
    {
        public Respuesta Grabar(MetodoEsterilizacion b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessMetodoEsterilizacion ga = new GestorDataAccessMetodoEsterilizacion();
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

        public listaMetodoEsterilizacion Listar(Int32 id)
        {
            listaMetodoEsterilizacion lb = new listaMetodoEsterilizacion();
            try
            {

                GestorDataAccessMetodoEsterilizacion ga = new GestorDataAccessMetodoEsterilizacion();
                lb = ga.Listar(id);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta Eliminar(Int32 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessMetodoEsterilizacion gb = new GestorDataAccessMetodoEsterilizacion();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1;
                r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstado(Int32 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessMetodoEsterilizacion gb = new GestorDataAccessMetodoEsterilizacion();
                r = gb.CambioEstado(id, estado);
            }
            catch (Exception ex)
            {
                r.estado = 1;
                r.descripcion = "La activacion fallo error:" + ex.Message.ToString();
            }
            return r;
        }
    }
}
