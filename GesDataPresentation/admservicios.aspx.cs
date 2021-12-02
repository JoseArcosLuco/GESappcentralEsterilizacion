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
    public partial class admservicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idServicio.Value), Convert.ToString(estadoServicio.Value));
            }
            if (accionAProcesar.Value.Equals("EliminarServicio"))
            {
                EliminarServicio(Convert.ToString(idServicio.Value));
            }

            datos.Text = Listar();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                ServicioClinico b = new ServicioClinico();
                Respuesta r = new Respuesta();

                b.nombre = cmpnombre.Value;
                b.codigoServicio = cmpcodigo.Value;
                b.descripcion = cmpdescripcion.Value;
                r = gb.Grabar(b);

                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);
                datos.Text = Listar();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Listar()
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                StringBuilder tbl = new StringBuilder();
                listaServicioClinico obj = gb.ListarServicioClinico();
                if (obj.List.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (ServicioClinico pdto in obj.List)
                    {
                        string identificador = pdto.idServicioClinico.ToString();
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
                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadestDesc + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        //tbl.Append(" <button type=\"button\" id=\"btnEliminar_" + identificador + "\" class=\"btn btn-primary btn-fw\" aria-label=\"Left Align\" title=\"Eliminar\" onclick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\"></i>Eliminar</button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEditar_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"Editar\" onclick=\"javascript:Editar(" + identificador + ")\"><span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span></button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEstado_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"" + cadest + "\" onclick=\"javascript:Estado(" + identificador + "," + pdto.estado.ToString() + ")\"><span class=\"glyphicon " + cadclass + "\" aria-hidden=\"true\"></span></button>");

                        tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoServicios(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:EliminarServicios(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");

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
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                ServicioClinico b = new ServicioClinico();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstadoServicioClinico(Convert.ToInt16(id), Convert.ToInt16(estado));

                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }

                datos.Text = Listar();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + ex.Message.ToString() + "); ", true);
            }
        }

        public void EliminarServicio(string id)
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                ServicioClinico b = new ServicioClinico();
                Respuesta r = new Respuesta();


                r = gb.EliminarServicioClinico(Convert.ToInt16(id));


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
    }
}