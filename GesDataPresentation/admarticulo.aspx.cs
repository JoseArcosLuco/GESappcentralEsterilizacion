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
    public partial class admArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstadoArticulos(Convert.ToString(idArticulo.Value), Convert.ToString(estadoArticulo.Value));
            }
            if (accionAProcesar.Value.Equals("EliminarArticulo"))
            {
                EliminarArticulo(Convert.ToString(idArticulo.Value));
            }

            datos.Text = Listar();
        }

        public string Listar()
        {
            try
            {
                GestorDataBusinessArticulo gb = new GestorDataBusinessArticulo();
                StringBuilder tbl = new StringBuilder();
                listaArticulo obj = gb.ListarArticulo();
                if (obj.ListArticulo.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Codigo Asig</th>");
                    tbl.Append("<th>Codigo Barra</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Codigo Asig</th>");
                    tbl.Append("<th>Codigo Barra</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (Articulo pdto in obj.ListArticulo)
                    {
                        string identificador = pdto.idArticulo.ToString();
                        string cadest = "Activar";
                        string cadestDesc = "Desactivo";
                        string cadclass = "glyphicon-remove";
                        if (pdto.estado == 1)
                        {
                            cadest = "Desactivar";
                            cadestDesc = "Activo";
                            cadclass = "glyphicon-ok";
                        }
                        tbl.Append("<tr id=\"fila" + identificador + "\">");
                        tbl.Append("<td>" + identificador + "</td>");
                        
                        tbl.Append("<td>" + pdto.nombreArticulo.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.codigoArticulo.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.codigoBarra.ToString() + "</td>");

                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadestDesc + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        //tbl.Append(" <button type=\"button\" id=\"btnEliminar_" + identificador + "\" class=\"btn btn-primary btn-fw\" aria-label=\"Left Align\" title=\"Eliminar\" onclick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\"></i>Eliminar</button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEditar_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"Editar\" onclick=\"javascript:Editar(" + identificador + ")\"><span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span></button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEstado_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"" + cadest + "\" onclick=\"javascript:Estado(" + identificador + "," + pdto.estado.ToString() + ")\"><span class=\"glyphicon " + cadclass + "\" aria-hidden=\"true\"></span></button>");

                        tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoArticulo(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:EliminarArticulo(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");

                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnconfigura_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\" Articulos que componen el Kit\" onclick=\"javascript:DynamicForm('mKitArticulo.aspx'," + identificador + ")\"><span class=\"glyphicon glyphicon-cog \" aria-hidden=\"true\"></span></button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnasignacion_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"Asignacion de Contenedor \" onclick=\"javascript:DynamicForm('mKitAsignarContenedor.aspx'," + identificador + ")\"><span class=\"glyphicon glyphicon-tasks\" aria-hidden=\"true\"></span></button>");
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

        public void CambiarEstadoArticulos(string idArticulo, string estado)
        {
            try
            {
                GestorDataBusinessArticulo gb = new GestorDataBusinessArticulo();
                Bodega b = new Bodega();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstadoArticulo(Convert.ToInt16(idArticulo), Convert.ToInt16(estado));

                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }

                datos.Text = Listar();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void EliminarArticulo(string idBodega)
        {
            try
            {
                GestorDataBusinessArticulo gb = new GestorDataBusinessArticulo();
                Articulo b = new Articulo();
                Respuesta r = new Respuesta();


                r = gb.EliminarArticulo(Convert.ToInt16(idBodega));


                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }
                datos.Text = Listar();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + ex.Message.ToString() + "); ", true);
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessArticulo gb = new GestorDataBusinessArticulo();
                Articulo b = new Articulo();
                Respuesta r = new Respuesta();


                b.nombreArticulo = cmpnombre.Value;
                b.nombreComercial = cmpnombrecomercial.Value;
                b.codigoArticulo = cmpcodigoarticulo.Value;
                b.codigoBarra = cmpcodigobarra.Value;
                b.codigoExterno = cmpcodigoexterno.Value;
                b.ancho = Convert.ToDecimal(cmpancho.Value);
                b.alto = Convert.ToDecimal(cmpalto.Value);
                b.profundidad = Convert.ToDecimal(cmpprofundidad.Value);

                b.defaultStockMinimo = Convert.ToInt16(cmpstockminimo.Value);
                b.defaultStockMaximo = Convert.ToInt16(cmpstockmaximo.Value);
                b.defaultStockCritico = Convert.ToInt16(cmpstockcritico.Value);

                b.defaultCosto = Convert.ToInt64(cmpcosto.Value);
                b.defaultPrecio = Convert.ToInt64(cmpprecio.Value);
                b.defaultRotacionMantencion = Convert.ToInt64(cmprotacion.Value);

                
                bool vencimiento;
                if (cmpvencimiento.Value.Equals("1"))
                {
                    vencimiento = true;
                }
                else
                {
                    vencimiento = false;
                }

                b.vencimiento = vencimiento;
                
                
                r = gb.GrabarArticulo(b);


                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('successfully');", true);
                datos.Text = Listar();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}