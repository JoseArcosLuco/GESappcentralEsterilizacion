using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessKitArticulo
    {
        public Respuesta Grabar(KitArticulo b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKitArticulo ga = new GestorDataAccessKitArticulo();
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

        public listaKitArticulo ListarKitArticulo(Int32 id)
        {
            listaKitArticulo lb = new listaKitArticulo();
            try
            {

                GestorDataAccessKitArticulo ga = new GestorDataAccessKitArticulo();
                lb = ga.Listar(id);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta EliminarKitArticulo(Int32 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKitArticulo gb = new GestorDataAccessKitArticulo();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1;
                r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoKitArticulo(Int32 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessKitArticulo gb = new GestorDataAccessKitArticulo();
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
