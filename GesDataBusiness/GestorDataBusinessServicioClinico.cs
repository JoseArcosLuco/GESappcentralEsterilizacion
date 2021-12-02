using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessServicioClinico
    {
        public Respuesta Grabar(ServicioClinico b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinico ga = new GestorDataAccessServicioClinico();
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

        public listaServicioClinico ListarServicioClinico()
        {
            listaServicioClinico lb = new listaServicioClinico();
            try
            {

                GestorDataAccessServicioClinico ga = new GestorDataAccessServicioClinico();
                lb = ga.Listar();
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta EliminarServicioClinico(Int16 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinico gb = new GestorDataAccessServicioClinico();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1; r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoServicioClinico(Int16 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessServicioClinico gb = new GestorDataAccessServicioClinico();
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
