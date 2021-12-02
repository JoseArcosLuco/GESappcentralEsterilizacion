using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessBodega
    {
        public Respuesta Grabar(Bodega b) {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessBodega ga = new GestorDataAccessBodega();
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

        public listaBodega ListarBodega() {
            listaBodega lb = new listaBodega();
            try
            {

                GestorDataAccessBodega ga = new GestorDataAccessBodega();
                lb = ga.Listar();
            }
            catch (Exception)
            {
                lb = null;
                
            }
            return lb;
        }

        public Respuesta EliminarBodega(Int16 idBodega) {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessBodega gb = new GestorDataAccessBodega();
                r = gb.Eliminar(idBodega);
            }
            catch (Exception ex)
            {
                r.estado = 1;r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoBodega(Int16 idBodega,int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessBodega gb = new GestorDataAccessBodega();
                r = gb.CambioEstado(idBodega,estado);
            }
            catch (Exception ex)
            {
                r.estado = 1; r.descripcion = "La activacion fallo error:" + ex.Message.ToString();
            }
            return r;
        }
    }
}
