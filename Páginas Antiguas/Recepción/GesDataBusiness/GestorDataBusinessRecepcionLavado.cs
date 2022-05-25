using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.model;
using ges.data.access;

namespace ges.data.business
{
    public class GestorDataBusinessRecepcionLavado
    {
        public listaRecepcionLavado Listar(Int64 idbodega, string codigotrazable)
        {
            listaRecepcionLavado lb = new listaRecepcionLavado();
            try
            {

                GestorDataAccessRecepcionLavado ga = new GestorDataAccessRecepcionLavado();
                lb = ga.Listar(idbodega, codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionLavado ListarPunto(Int64 idbodega)
        {
            listaRecepcionLavado lb = new listaRecepcionLavado();
            try
            {

                GestorDataAccessRecepcionLavado ga = new GestorDataAccessRecepcionLavado();
                lb = ga.Listar(idbodega);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionLavado ListarRevisiones(string codigotrazable)
        {
            listaRecepcionLavado lb = new listaRecepcionLavado();
            try
            {

                GestorDataAccessRecepcionLavado ga = new GestorDataAccessRecepcionLavado();
                if (!codigotrazable.Equals(""))
                    lb = ga.ListarRevisiones(codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta GrabarRecepcionLavado(RecepcionLavado rs)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessRecepcionLavado gda = new GestorDataAccessRecepcionLavado();
                r = gda.GrabarRecepcionLavado(rs);
            }
            catch (Exception ex)
            {

                throw;
            }
            return r;
        }
    }
}
