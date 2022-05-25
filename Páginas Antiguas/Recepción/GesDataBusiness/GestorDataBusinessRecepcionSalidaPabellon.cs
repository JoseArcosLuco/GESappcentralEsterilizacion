using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.access;
using ges.data.model;

namespace ges.data.business
{
    public class GestorDataBusinessRecepcionSalidaPabellon
    {
        public listaRecepcionSalidaPabellon Listar(Int64 idbodega, string codigotrazable)
        {
            listaRecepcionSalidaPabellon lb = new listaRecepcionSalidaPabellon();
            try
            {

                GestorDataAccessRecepcionSalidaPabellon ga = new GestorDataAccessRecepcionSalidaPabellon();
                lb = ga.Listar(idbodega, codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionSalidaPabellon ListarPunto(Int64 idbodega)
        {
            listaRecepcionSalidaPabellon lb = new listaRecepcionSalidaPabellon();
            try
            {

                GestorDataAccessRecepcionSalidaPabellon ga = new GestorDataAccessRecepcionSalidaPabellon();
                lb = ga.Listar(idbodega);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionSalidaPabellon ListarRevisiones(string codigotrazable)
        {
            listaRecepcionSalidaPabellon lb = new listaRecepcionSalidaPabellon();
            try
            {

                GestorDataAccessRecepcionSalidaPabellon ga = new GestorDataAccessRecepcionSalidaPabellon();
                if (!codigotrazable.Equals(""))
                    lb = ga.ListarRevisiones(codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta GrabarRecepcionSalidaPabellon(RecepcionSalidaPabellon rs) {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessRecepcionSalidaPabellon gda = new GestorDataAccessRecepcionSalidaPabellon();
                r = gda.GrabarRecepcionSalidaPabellon(rs);
            }
            catch (Exception ex)
            {

                throw;
            }
            return r;
        }
    }
}
