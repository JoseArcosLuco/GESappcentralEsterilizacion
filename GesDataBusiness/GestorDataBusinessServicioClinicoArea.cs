using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessServicioClinicoArea
    {
        public Respuesta Grabar(ServicioClinicoArea b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinicoArea ga = new GestorDataAccessServicioClinicoArea();
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

        public listaServicioClinicoArea ListarServicioClinicoArea(Int64 id)
        {
            listaServicioClinicoArea lb = new listaServicioClinicoArea();
            try
            {

                GestorDataAccessServicioClinicoArea ga = new GestorDataAccessServicioClinicoArea();
                lb = ga.Listar(id);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta EliminarServicioClinicoArea(Int16 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinicoArea gb = new GestorDataAccessServicioClinicoArea();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1; r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoServicioClinicoArea(Int16 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinicoArea gb = new GestorDataAccessServicioClinicoArea();
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
