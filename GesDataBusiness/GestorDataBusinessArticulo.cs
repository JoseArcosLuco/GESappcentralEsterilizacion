using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessArticulo
    {
        public listaArticulo ListarArticulo() {

            listaArticulo list = new listaArticulo();
            GestorDataAccessArticulo ga = new GestorDataAccessArticulo();
            Respuesta r = new Respuesta();

            try
            {
                list = ga.Listar();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public Respuesta GrabarArticulo(Articulo obj) {
            GestorDataAccessArticulo ga = new GestorDataAccessArticulo();
            Respuesta r = new Respuesta();
            try
            {
                r = ga.Grabar(obj);
            }
            catch (Exception)
            {

                throw;
            }
            return r;
        }

        public Respuesta EliminarArticulo(Int64 idArticulo) {
            GestorDataAccessArticulo ga = new GestorDataAccessArticulo();
            Respuesta r = new Respuesta();
            try
            {
                r = ga.Eliminar(idArticulo);
            }
            catch (Exception)
            {

                throw;
            }
            return r;
        }

        public Respuesta CambiarEstadoArticulo(Int16 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessArticulo gb = new GestorDataAccessArticulo();
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
