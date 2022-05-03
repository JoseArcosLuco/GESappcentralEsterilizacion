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
    public partial class admpabellones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idPabellon.Value), Convert.ToString(estadoPabellon.Value));
            }
            if (accionAProcesar.Value.Equals("EliminarPabellon"))
            {
                EliminarKitArticulo(Convert.ToString(idPabellon.Value));
            }

            //datos.Text = Listar(Convert.ToInt32(HttpContext.Current.Request.QueryString["idServicio"].ToString()));

            comboServicios.Text = CrearComboServicios("cmpidservicio", idServicio.Value, true);
            comboServiciosAgregar.Text = CrearComboServicios("cmpidservicioAgregar", idServicio.Value, false);

            //De actualizar la pagina con un idServicio, genera la lista con los pabellones de ese servicio, de enviar 0 lista ningun elemento
            if (idServicio.Value != "") { 
                datos.Text = Listar(Convert.ToInt32(idServicio.Value)); }
            else{ 
                datos.Text = Listar(0); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessPabellones gb = new GestorDataBusinessPabellones();
                Pabellones b = new Pabellones();
                Respuesta r = new Respuesta();
                b.idServicioClinico = Convert.ToInt32(idServicio.Value);
                b.nombre = cmpnombre.Value;
                b.descripcion = cmpdescripcion.Value;

                if (b.idServicioClinico != 0)
                {

                    r = gb.Grabar(b);

                    if (r.estado == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + r.descripcion + "!');", true);
                        cmpnombre.Value = "";
                        cmpdescripcion.Value = "";
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);
                        cmpnombre.Value = "";
                        cmpdescripcion.Value = "";
                    }

                    datos.Text = Listar(Convert.ToInt32(idServicio.Value));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void Buscar_Click(object sender, EventArgs e)
        {
            datos.Text = Listar(Convert.ToInt32(idServicio.Value));

        }

        public static string CrearComboServicios(string nombrecampo, string idServicio, bool lista)
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                listaServicioClinico obj = gb.ListarServicioClinico();
                string combo;

                if (lista) {
                    combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" aria-required=\"True\" required=\"required\" \"> "; }
                else{ 
                    combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioServicioAgregar()\" aria-required=\"True\" required=\"required\" \"> "; }

                combo = combo + "<option value=\"\">Seleccione</option>";
                if (obj.List.Count() > 0)
                {

                    IEnumerable<ServicioClinico> query = obj.List.OrderBy(num => num.nombre);

                    foreach (var l in query)
                    {
                        string t1 = l.idServicioClinico.ToString();
                        string t2 = l.nombre.ToString();
                        string selected = "selected";
                        if (idServicio == t1 && lista)
                        {
                            combo = combo + "<option value='" + t1 + "' " + selected + ">" + t2 + "</option>";
                        }
                        else
                        {
                            combo = combo + "<option value='" + t1 + "'>" + t2 + "</option>";
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

        public string Listar(Int32 id)
        {
            try
            {
                GestorDataBusinessPabellones gb = new GestorDataBusinessPabellones();
                StringBuilder tbl = new StringBuilder();
                listaPabellones obj = gb.ListarPabellones(id);
                if (obj.ListPabellones.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Servicio</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Descripción</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Servicio</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Descripción</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (Pabellones pdto in obj.ListPabellones)
                    {
                        string identificador = pdto.idPabellon.ToString();
                        string cadest = "Activar";
                        string cadestDesc = "Desactivo";
                        string cadclass = "glyphicon-remove";
                        if (pdto.estado == 1)
                        {
                            cadest = "Desactivar";
                            cadestDesc = "Activo";
                            cadclass = "glyphicon-ok";
                        }
                        if (pdto.idServicioClinico == id )
                        {
                            tbl.Append("<tr id=\"fila" + identificador + "\">");
                            tbl.Append("<td>" + identificador + "</td>");
                            tbl.Append("<td>" + pdto.nombreServicio.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.nombre.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.descripcion.ToString() + "</td>");
                            tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadestDesc + "</td>");
                            tbl.Append("<td class=\"text-right\">");

                            tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn-secondary btn-fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoPabellon(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                            tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:EliminarPabellon(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");

                            tbl.Append("</td></tr>");
                        }
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
                GestorDataBusinessPabellones gb = new GestorDataBusinessPabellones();
                Pabellones b = new Pabellones();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstadoPabellon(Convert.ToInt32(id), Convert.ToInt16(estado));

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
                GestorDataBusinessPabellones gb = new GestorDataBusinessPabellones();
                Pabellones b = new Pabellones();
                Respuesta r = new Respuesta();


                r = gb.EliminarPabellon(Convert.ToInt32(id));


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