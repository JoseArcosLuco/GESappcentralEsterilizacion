using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ges.data.business;
using ges.data.model;
using System.Text;

namespace ges.data.presentation
{
    public partial class recepcioninstrumental : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            comboAreaRecepcion.Text = CrearComboRecepcion("cmpAreaRecepcion", idBodega.Value);

            if (idBodega.Value != "")
            {
                datosEnBodega.Text = ListarPunto(Convert.ToInt64(idBodega.Value));
            }
            else
            {
                datosEnBodega.Text = "Debe seleccionar un área de recepción.";
            }

            if(datosEnBodega.Text == "")
            {
                datosEnBodega.Text = "0 Registros Encontrados!";
            }
        }

        public string CrearComboRecepcion(string nombrecampo, string idBodega)
        {
            try
            {
                GestorDataBusinessBodega gb = new GestorDataBusinessBodega();
                listaBodega obj = gb.ListarBodega();
                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioRecepcion()\" aria-required=\"True\" required=\"required\" \"> "
                                + " <option value =\"\">Seleccione</option>";

                if (obj.ListBodega.Count() > 0)
                {

                    IEnumerable<Bodega> query = obj.ListBodega.OrderBy(num => num.idBodega);

                    foreach (var l in query)
                    {
                        string t1 = l.idBodega.ToString();
                        string t2 = l.nombreBodega.ToString();
                        string selected = "selected";
                        if (idBodega == t1)
                        {
                            combo = combo + "<option value='" + t1 + "' " + selected + ">" + t1 + " - " + t2 + "</option>";
                            nombreBodega.Value = t2;
                        }
                        else
                        {
                            combo = combo + "<option value='" + t1 + "'>" + t1 + " - " + t2 + "</option>";
                        }
                    }
                }
                combo = combo + "</select>";
                return combo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Listar(Int64 idBodega, string codigoTrazable)
        {
            try
            {
                GestorDataBusinessRecepcionInstrumental gb = new GestorDataBusinessRecepcionInstrumental();
                StringBuilder tbl = new StringBuilder();
                listaRecepcionInstrumental obj = gb.Listar(idBodega, codigoTrazable);
                if (obj.List.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"table\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Articulo</th>");
                    tbl.Append("<th>Rotaciones</th>");
                    tbl.Append("<th>Bodega Actual</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");

                    foreach (RecepcionInstrumental pdto in obj.List)
                    {
                        string identificador = pdto.codigoTrazable.ToString();

                        tbl.Append("<tr id=\"fila" + identificador + "\">");
                        tbl.Append("<td>" + identificador + "</td>");
                        tbl.Append("<td>" + pdto.nombreArticulo.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.cantidadRotacion.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.nombreBodega.ToString() + "</td>");
                        tbl.Append("<td><button id=\"btnasignar_" + identificador + "\" type=\"button\" class=\"btn btn-success btn-fw\" runat=\"server\" OnClick=\"javascript:AsignarABodega('" + identificador + "','" + pdto.nombreArticulo + "' )\"><i class=\"mdi mdi-download\">Asignar a Bodega + Revision</i></button></td>");
                        tbl.Append("</tr>");
                    }
                    tbl.Append("</table>");
                }
                return tbl.ToString();
            }
            catch (Exception ex)
            {
                string descripcion = ex.Message.ToString().Replace(System.Environment.NewLine, "<br>").Replace("\"", "'");
                ClientScript.RegisterStartupScript(GetType(), "alerta", "mensajeria(\"#contenedor\", \"alertaparam\", \"PARAMETROS\", \"" + descripcion + "\", \"ERROR\");", true);
                return descripcion;
            }
        }

        public string ListarPunto(Int64 idBodega)
        {
            try
            {
                GestorDataBusinessRecepcionInstrumental gb = new GestorDataBusinessRecepcionInstrumental();
                StringBuilder tbl = new StringBuilder();
                listaRecepcionInstrumental obj = gb.ListarPunto(idBodega);
                if (obj.List.Count > 0)
                {

                    tbl.Append("<table class=\"table table-striped table-bordered table-sm\"><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre Contenedor</th>");
                    tbl.Append("<th>Fecha Hora Recepción</th>");
                    tbl.Append("<th>Rotaciones</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tr>");

                    if (obj.List.Count() > 0)
                    {
                        foreach (RecepcionInstrumental pdto in obj.List)
                        {
                            tbl.Append("<tr>");
                            tbl.Append("<td>" + pdto.codigoTrazable.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.nombreArticulo.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.fechaAct.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.cantidadRotacion.ToString() + "</td>");
                            tbl.Append("<td>-</td>");
                            tbl.Append("</tr>");
                        }
                    }

                    tbl.Append("</table>");
                }
                return tbl.ToString();
            }
            catch (Exception ex)
            {
                string descripcion = ex.Message.ToString().Replace(System.Environment.NewLine, "<br>").Replace("\"", "'");
                ClientScript.RegisterStartupScript(GetType(), "alerta", "mensajeria(\"#contenedor\", \"alertaparam\", \"PARAMETROS\", \"" + descripcion + "\", \"ERROR\");", true);
                return descripcion;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 idBodegaEnvio = Convert.ToInt64(idBodega.Value);
                string codigotrazableenvio = cmpcodigobusqueda.Value;

                datosSalida.Text = this.Listar(idBodegaEnvio, codigotrazableenvio);

                if (datosSalida.Text == "")
                    datosSalida.Text = "0 Registros Encontrados!";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}