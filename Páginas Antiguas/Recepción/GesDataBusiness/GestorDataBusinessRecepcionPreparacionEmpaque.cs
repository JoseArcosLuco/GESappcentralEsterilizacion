using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.model;
using ges.data.access;
namespace ges.data.business
{
    public class GestorDataBusinessRecepcionPreparacionEmpaque
    {
        public listaRecepcionPreparacionEmpaque Listar(Int64 idbodega, string codigotrazable)
        {
            listaRecepcionPreparacionEmpaque lb = new listaRecepcionPreparacionEmpaque();
            try
            {

                GestorDataAccessRecepcionPreparacionEmpaque ga = new GestorDataAccessRecepcionPreparacionEmpaque();
                lb = ga.Listar(idbodega, codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionPreparacionEmpaque ListarPunto(Int64 idbodega)
        {
            listaRecepcionPreparacionEmpaque lb = new listaRecepcionPreparacionEmpaque();
            try
            {

                GestorDataAccessRecepcionPreparacionEmpaque ga = new GestorDataAccessRecepcionPreparacionEmpaque();
                lb = ga.Listar(idbodega);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public listaRecepcionPreparacionEmpaque ListarRevisiones(string codigotrazable)
        {
            listaRecepcionPreparacionEmpaque lb = new listaRecepcionPreparacionEmpaque();
            try
            {

                GestorDataAccessRecepcionPreparacionEmpaque ga = new GestorDataAccessRecepcionPreparacionEmpaque();
                if (!codigotrazable.Equals(""))
                    lb = ga.ListarRevisiones(codigotrazable);
            }
            catch (Exception)
            {
                lb = null;

            }
            return lb;
        }

        public Respuesta GrabarRecepcionLavado(RecepcionPreparacionEmpaque rs)
        {
            Respuesta r = new Respuesta();
            try
            {
                GestorDataAccessRecepcionPreparacionEmpaque gda = new GestorDataAccessRecepcionPreparacionEmpaque();
                r = gda.GrabarRecepcionPreparacionEmpaque(rs);
            }
            catch (Exception ex)
            {

                throw;
            }
            return r;
        }
    }
}
