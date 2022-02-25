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
    public partial class admkitarticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                lblIdKit.Text = idKit.Value;
                lblNombreKit.Text = nombreKit.Value;
            }

            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idKitArticulo.Value), Convert.ToString(estadoKitArticulo.Value));
            }
            if (accionAProcesar.Value.Equals("EliminarKitArticulo"))
            {
                EliminarKitArticulo(Convert.ToString(idKitArticulo.Value));
            }
            if (accionAProcesar.Value.Equals("AsignarKitArticulo"))
            {
                //AsignarKitArticulo(Convert.ToString(idKitArticulo.Value));
            }

            datos.Text = Listar(Convert.ToInt32(idKit.Value));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessKitArticulo gb = new GestorDataBusinessKitArticulo();
                KitArticulo b = new KitArticulo();
                Respuesta r = new Respuesta();
                b.idKit = Convert.ToInt32(idKit.Value);
                b.idArticulo = Convert.ToInt32(cmpidarticulo.Value);
                b.cantidadArticulo = Convert.ToInt32(cmpcantidad.Value);
                r = gb.Grabar(b);
                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + r.descripcion + "!');", true);
                }else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);

                    cmpidarticulo.Value = "";
                    cmpcantidad.Value = "";
                }
                
                datos.Text = Listar(Convert.ToInt32(idKit.Value));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Listar(Int32 id)
        {
            try
            {
                GestorDataBusinessKitArticulo gb = new GestorDataBusinessKitArticulo();
                StringBuilder tbl = new StringBuilder();
                listaKitArticulo obj = gb.ListarKitArticulo(id);
                if (obj.ListKitArticulo.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Cantidad Articulos</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Cantidad Articulos</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (KitArticulo pdto in obj.ListKitArticulo)
                    {
                        string identificador = pdto.idKitArticulo.ToString();
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
                        tbl.Append("<td>" + pdto.nombre.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.cantidadArticulo.ToString() + "</td>");
                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadestDesc + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        //tbl.Append(" <button type=\"button\" id=\"btnEliminar_" + identificador + "\" class=\"btn btn-primary btn-fw\" aria-label=\"Left Align\" title=\"Eliminar\" onclick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\"></i>Eliminar</button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEditar_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"Editar\" onclick=\"javascript:Editar(" + identificador + ")\"><span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span></button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEstado_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"" + cadest + "\" onclick=\"javascript:Estado(" + identificador + "," + pdto.estado.ToString() + ")\"><span class=\"glyphicon " + cadclass + "\" aria-hidden=\"true\"></span></button>");

                        tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoKitArticulo(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:EliminarKitArticulo(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");

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

        public void CambiarEstado(string id, string estado)
        {
            try
            {
                GestorDataBusinessKitArticulo gb = new GestorDataBusinessKitArticulo();
                KitArticulo b = new KitArticulo();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstadoKitArticulo(Convert.ToInt32(id), Convert.ToInt16(estado));

                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }

                datos.Text = Listar(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + ex.Message.ToString() + "); ", true);
                throw;
            }
        }

        public void EliminarKitArticulo(string id)
        {
            try
            {
                GestorDataBusinessKitArticulo gb = new GestorDataBusinessKitArticulo();
                KitArticulo b = new KitArticulo();
                Respuesta r = new Respuesta();


                r = gb.EliminarKitArticulo(Convert.ToInt32(id));


                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }
                datos.Text = Listar(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + ex.Message.ToString() + "); ", true);
                throw;
            }
        }
    }
}