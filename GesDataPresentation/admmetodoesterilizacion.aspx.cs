using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ges.data.business;
using ges.data.model;


namespace ges.data.presentation
{
    public partial class admmetodoesterilizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblIdMaquinaEsterilizacion.Text = idMaquinaEsterilizacion.Value;
                lblNombreMaquinaEsterilizacion.Text = nombreMaquina.Value;
                
            }

            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idMetodoEsterilizacion.Value), Convert.ToString(estadoMetodoEsterilizacion.Value));
            }
            if (accionAProcesar.Value.Equals("EliminarMetodo"))
            {
                EliminarMetodoEsterilizacion(Convert.ToString(idMetodoEsterilizacion.Value));
            }
            

            datos.Text = Listar(Convert.ToInt32(idMaquinaEsterilizacion.Value));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessMetodoEsterilizacion gb = new GestorDataBusinessMetodoEsterilizacion();
                MetodoEsterilizacion b = new MetodoEsterilizacion();
                Respuesta r = new Respuesta();
                //b.idMetodoEsterilizacion = Convert.ToInt32(idMetodoEsterilizacion.Value);
                b.idMaquinaEsterilizacion = Convert.ToInt32(idMaquinaEsterilizacion.Value);
                b.codigo = cmpcodigo.Value;
                b.nombre = cmpnombremetodo.Value;

                r = gb.Grabar(b);
                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + r.descripcion + "!');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);

                    cmpcodigo.Value = "";
                    cmpnombremetodo.Value = "";
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
                GestorDataBusinessMetodoEsterilizacion gb = new GestorDataBusinessMetodoEsterilizacion();
                StringBuilder tbl = new StringBuilder();
                listaMetodoEsterilizacion obj = gb.Listar(id);
                if (obj.List.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Id</th>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Id</th>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Nombre</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (MetodoEsterilizacion pdto in obj.List)
                    {
                        string identificador = pdto.idMetodoEsterilizacion.ToString();
                        string cadest = "Activar";
                        string cadclass = "glyphicon-remove";
                        if (pdto.estado == 1)
                        {
                            cadest = "Desactivar";
                            cadclass = "glyphicon-ok";
                        }
                        tbl.Append("<tr id=\"fila" + identificador + "\">");
                        tbl.Append("<td>" + identificador + "</td>");
                        tbl.Append("<td>" + pdto.codigo.ToString() + "</td>");
                        tbl.Append("<td>" + pdto.nombre.ToString() + "</td>");
                        tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + pdto.estado + "\">" + cadest + "</td>");
                        tbl.Append("<td class=\"text-right\">");
                        tbl.Append("&nbsp;<button id=\"btncambiaestado_" + identificador + "\" type=\"button\" class=\"btn btn - secondary btn - fw\" runat=\"server\" OnClick=\"javascript:CambiarEstado(" + identificador + "," + pdto.estado.ToString() + ")\"><i class=\"mdi mdi-cloud-download\">" + cadest + "</i></button>");
                        tbl.Append("&nbsp;<button id=\"btneliminar_" + identificador + "\" type=\"button\" class=\"btn btn-danger btn-fw\" runat=\"server\" OnClick=\"javascript:Eliminar(" + identificador + ")\"><i class=\"mdi mdi-alert-outline\">Eliminar</i></button>");
                        
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
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + descripcion + "); ", true);


                //ClientScript.RegisterStartupScript(GetType(), "alerta", "mensajeria(\"#contenedor\", \"alertaparam\", \"PARAMETROS\", \"" + descripcion + "\", \"ERROR\");", true);
                return descripcion;
            }
        }

        public void CambiarEstado(string id, string estado)
        {
            try
            {
                GestorDataBusinessMetodoEsterilizacion gb = new GestorDataBusinessMetodoEsterilizacion();
                MetodoEsterilizacion b = new MetodoEsterilizacion();
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

        public void EliminarMetodoEsterilizacion(string id)
        {
            try
            {
                GestorDataBusinessMetodoEsterilizacion gb = new GestorDataBusinessMetodoEsterilizacion();
                MetodoEsterilizacion b = new MetodoEsterilizacion();
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