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
    public partial class admmaquinaesterilizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              if (idMaquinaEsterilizacion.Value == "" || idMaquinaEsterilizacion.Value == null)
                {
                    idMaquinaEsterilizacion.Value = "0";
                }
            }

            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idMaquinaEsterilizacion.Value), Convert.ToString(estadoMaquinaEsterilizacion.Value));

                idMaquinaEsterilizacion.Value = "0";
            }
            if (accionAProcesar.Value.Equals("EliminarMaquinaEsterilizacion"))
            {
                Eliminar(Convert.ToString(idMaquinaEsterilizacion.Value));

                idMaquinaEsterilizacion.Value = "0";
            }
            

            datos.Text = Listar(Convert.ToInt32(idMaquinaEsterilizacion.Value));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessMaquinaEsterilizacion gb = new GestorDataBusinessMaquinaEsterilizacion();
                MaquinaEsterilizacion b = new MaquinaEsterilizacion();
                Respuesta r = new Respuesta();
                b.codigo = cmpcodigo.Value;
                b.nombre = cmpnombre.Value;
                b.ciclosMantencion = Convert.ToInt32(cmpciclos.Value);
                r = gb.Grabar(b);
                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + r.descripcion + "!');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);

                    cmpcodigo.Value = "";
                    cmpnombre.Value = "";
                    cmpciclos.Value = "";
                }

                datos.Text = Listar(Convert.ToInt32(idMaquinaEsterilizacion.Value));
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
                GestorDataBusinessMaquinaEsterilizacion gb = new GestorDataBusinessMaquinaEsterilizacion();
                StringBuilder tbl = new StringBuilder();
                listaMaquinaEsterilizacion obj = gb.Listar(id);
                if (obj.List.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Cantidad Ciclos</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Cantidad Ciclos</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (MaquinaEsterilizacion pdto in obj.List)
                    {
                        string identificador = pdto.idMaquinaEsterilizacion.ToString();
                        string cadest = "Inactivo";
                        string cadclass = "glyphicon-remove";
                        if (pdto.estado == 1)
                        {
                            cadest = "Activo";
                            cadclass = "glyphicon-ok";
                        }
                        tbl.Append("<tr id=\"fila" + identificador + "\">");
                        tbl.Append("<td>" + identificador + "</td>");
                        tbl.Append("<td>" + pdto.nombre.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.ciclosMantencion.ToString() + "</td>");
                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadest + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        //tbl.Append(" <button type=\"button\" id=\"btnEliminar_" + identificador + "\" class=\"btn btn-primary btn-fw\" aria-label=\"Left Align\" title=\"Eliminar\" onclick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\"></i>Eliminar</button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEditar_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"Editar\" onclick=\"javascript:Editar(" + identificador + ")\"><span class=\"glyphicon glyphicon-pencil\" aria-hidden=\"true\"></span></button>");
                        //tbl.Append(" &nbsp;<button type=\"button\" id=\"btnEstado_" + identificador + "\" class=\"btn btn-info\" aria-label=\"Left Align\" title=\"" + cadest + "\" onclick=\"javascript:Estado(" + identificador + "," + pdto.estado.ToString() + ")\"><span class=\"glyphicon " + cadclass + "\" aria-hidden=\"true\"></span></button>");

                        tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstado(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");
                        tbl.Append("&nbsp;<button id=\"btnasignar_" + identificador + "\" type=\"button\" class=\"btn btn-success btn-fw\" runat=\"server\" OnClick=\"javascript:AsignarMetodoEsterilizacion(" + identificador + ",'" + pdto.nombre.ToString() + "')\"><i class=\"mdi mdi-upload\">Asignar Metodo</i></button>");
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
                //ClientScript.RegisterStartupScript(GetType(), "alerta", "mensajeria(\"#contenedor\", \"alertaparam\", \"PARAMETROS\", \"" + descripcion + "\", \"ERROR\");", true);
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:-->' " + descripcion + "); ", true);
                return descripcion;
            }
        }

        public void CambiarEstado(string id, string estado)
        {
            try
            {
                GestorDataBusinessMaquinaEsterilizacion gb = new GestorDataBusinessMaquinaEsterilizacion();
                MaquinaEsterilizacion b = new MaquinaEsterilizacion();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstado(Convert.ToInt32(id), Convert.ToInt16(estado));

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

        public void Eliminar(string id)
        {
            try
            {
                GestorDataBusinessMaquinaEsterilizacion gb = new GestorDataBusinessMaquinaEsterilizacion();
                MaquinaEsterilizacion b = new MaquinaEsterilizacion();
                Respuesta r = new Respuesta();


                r = gb.Eliminar(Convert.ToInt32(id));


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