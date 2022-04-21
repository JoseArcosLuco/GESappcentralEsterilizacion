using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessPabellones
    {
        public Respuesta Grabar(Pabellones b)
        {

            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessPabellones ga = new GestorDataAccessPabellones();
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

        public listaPabellones ListarPabellones(Int32 id)
        {
            listaPabellones lb = new listaPabellones();
            try
            {
                GestorDataAccessPabellones ga = new GestorDataAccessPabellones();
                lb = ga.Listar(id);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta EliminarPabellon(Int32 id)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessPabellones gb = new GestorDataAccessPabellones();
                r = gb.Eliminar(id);
            }
            catch (Exception ex)
            {
                r.estado = 1;
                r.descripcion = "La eliminación fallo error:" + ex.Message.ToString();
            }
            return r;
        }
        public Respuesta CambiarEstadoPabellon(Int32 id, int estado)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessPabellones gb = new GestorDataAccessPabellones();
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
