using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.model;
using ges.data.access;

namespace ges.data.business
{
    public class GestorDataBusinessRecepcionInstrumental
    {
        public listaRecepcionInstrumental Listar(Int64 idbodega, string codigotrazable)
        {
            listaRecepcionInstrumental lb = new listaRecepcionInstrumental();
            try
            {
                GestorDataAccessRecepcionInstrumental ga = new GestorDataAccessRecepcionInstrumental();
                lb = ga.Listar(idbodega, codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionInstrumental ListarPunto(Int64 idbodega)
        {
            listaRecepcionInstrumental lb = new listaRecepcionInstrumental();
            try
            {
                GestorDataAccessRecepcionInstrumental ga = new GestorDataAccessRecepcionInstrumental();
                lb = ga.Listar(idbodega);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionInstrumental ListarRevisiones(string codigotrazable)
        {
            listaRecepcionInstrumental lb = new listaRecepcionInstrumental();
            try
            {
                GestorDataAccessRecepcionInstrumental ga = new GestorDataAccessRecepcionInstrumental();
                if (!codigotrazable.Equals(""))
                    lb = ga.ListarRevisiones(codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta GrabarRecepcionInstrumental(RecepcionInstrumental rs)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessRecepcionInstrumental gda = new GestorDataAccessRecepcionInstrumental();
                r = gda.GrabarRecepcionInstrumental(rs);
            }
            catch (Exception ex)
            {

                throw;
            }
            return r;
        }
    }
}
