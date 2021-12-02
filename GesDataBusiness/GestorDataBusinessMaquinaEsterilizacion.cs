using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessMaquinaEsterilizacion
    {
        public Respuesta Grabar(MaquinaEsterilizacion b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessMaquinaEsterilizacion ga = new GestorDataAccessMaquinaEsterilizacion();
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

        public listaMaquinaEsterilizacion Listar(Int32 id)
        {
            listaMaquinaEsterilizacion lb = new listaMaquinaEsterilizacion();
            try
            {

                GestorDataAccessMaquinaEsterilizacion ga = new GestorDataAccessMaquinaEsterilizacion();
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
                GestorDataAccessMaquinaEsterilizacion gb = new GestorDataAccessMaquinaEsterilizacion();
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
                GestorDataAccessMaquinaEsterilizacion gb = new GestorDataAccessMaquinaEsterilizacion();
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
