using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ges.data.model;
using ges.data.business;
using System.Text;

namespace ges.data.presentation
{
    public partial class recepcionsalidapabellon : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //idUsuario.Value = Session["usuarioId"].ToString();

            try
            {
                listaRecepcionSalidaPabellon list = new listaRecepcionSalidaPabellon();
                GestorDataBusinessRecepcionSalidaPabellon g = new GestorDataBusinessRecepcionSalidaPabellon();
                list = g.ListarPunto(1);
                datosEnBodega.Text = ListarPunto(list);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Listar(Int64 idBodega,string codigoTrazable)
        {
            try
            {
                GestorDataBusinessRecepcionSalidaPabellon gb = new GestorDataBusinessRecepcionSalidaPabellon();
                StringBuilder tbl = new StringBuilder();
                listaRecepcionSalidaPabellon obj = gb.Listar(idBodega,codigoTrazable);
                if (obj.List.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"table\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre Articulo</th>");
                    tbl.Append("<th>Cantidad Rotacion</th>");
                    tbl.Append("<th>Fecha Mantencion</th>");
                    tbl.Append("<th>Bodega</th>");
                    tbl.Append("<th>Fecha Actualizacion</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    //tbl.Append("<tfoot><tr>");
                    //tbl.Append("<th>Codigo</th>");
                    //tbl.Append("<th>Nombre Articulo</th>");
                    //tbl.Append("<th>Cantidad Rotacion</th>");
                    //tbl.Append("<th>Fecha Mantencion</th>");
                    //tbl.Append("<th>Bodega</th>");
                    //tbl.Append("<th>Fecha Actualizacion</th>");
                    //tbl.Append("<th>Estado</th>");
                    //tbl.Append("<th>Acciones</th>");
                    //tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (RecepcionSalidaPabellon pdto in obj.List)
                    {
                        string identificador = pdto.codigoTrazable.ToString();
                        string cadest = "Inactivo";
                        string cadclass = "glyphicon-remove";
                        if (pdto.estado == 1)
                        {
                            cadest = "Activo";
                            cadclass = "glyphicon-ok";
                        }
                        tbl.Append("<tr id=\"fila" + identificador + "\">");
                        tbl.Append("<td>" + identificador + "</td>");
                        tbl.Append("<td>" + pdto.nombreArticulo.ToString() + "</td>");

                        tbl.Append("<td>" + pdto.cantidadRotacion.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.fechaMantencion.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.nombreBodega.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.fechaAct.ToString() + "</td>");


                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadest + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        //tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoServicios(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btnasignar_" + identificador + "\" type=\"button\" class=\"btn btn-success btn-fw\" runat=\"server\" OnClick=\"javascript:AsignarABodega('" + identificador + "','"+ pdto.nombreArticulo+ "' )\"><i class=\"mdi mdi-download\">Asignar a Bodega + Revision</i></button>");
                        //tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:EliminarServicios(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");
                        tbl.Append("</td></tr>");
                    }
                    tbl.Append("</tbody>");
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


        public static string ListarPunto(listaRecepcionSalidaPabellon result)
        {
            try
            {
                string combo = "";
                combo = combo + "<table class=\"table table-striped table-bordered table-sm\"><tr>";
                combo = combo + "<th>Codigo</th><th>Nombre Contenedor</th><th>Fecha Hora Recepcion</th><th>Rotaciones</th><th>Acciones</th></tr>";
                if (result.List.Count() > 0)
                {
                    foreach (var l in result.List)
                    {
                        string t1 = l.codigoTrazable.ToString();
                        string t2 = l.nombreArticulo.ToString();
                        string t3 = l.fechaAct.ToString();
                        string t4 = l.cantidadRotacion.ToString();
                        

                        combo = combo + "<tr><td>" + t1 + "</td><td>" + t2 + "</td><td>" + t3 + "</td><td>" + t4 + "</td><td>-</td></tr>";
                    }
                }
                combo = combo + "</table>";
                return combo;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                

                Int64 idBodegaEnvio = Convert.ToInt64(idBodega.Value);
                string codigotrazableenvio = cmpcodigobusqueda.Value;

                datosSalida.Text =  this.Listar(idBodegaEnvio, codigotrazableenvio);

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