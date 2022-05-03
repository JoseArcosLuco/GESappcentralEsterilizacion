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
    public partial class admsolicitudes : System.Web.UI.Page
    {
        List<(int idEstado, string descEstado, string accionEstado)> estadoSolicitud = new List<(int, string, string)>()
                        {
                            (1,"En Revisión","En Revisión") ,
                            (2,"En Preparación","En Preparación"),
                            (3,"Listo para Entregar","Listo para Entregar"),
                            (4,"Entregado","Entregar")
                        };
        protected void Page_Load(object sender, EventArgs e)
        {
            idUsuario.Value = Session["usuarioId"].ToString();

            if (accionAProcesar.Value.Equals("CambiarEstado"))
            {
                CambiarEstado(Convert.ToString(idAgenda.Value), Convert.ToString(idEstado.Value));
                accionAProcesar.Value = "";
            }

            comboPabellon.Text = CrearComboPabellon("cmpidpabellon", idPabellon.Value);
            comboEstado.Text = CrearComboEstado("cmpidestado", estadoAgenda.Value);
            datos.Text = Listar(Convert.ToInt32(idUsuario.Value),idPabellon.Value,estadoAgenda.Value);
        }

        /*
        protected void Buscar_Click(object sender, EventArgs e)
        {
            estadoAgenda.Value = cmpidestado.Value;
            idPabellon.Value = cmpidpabellon.Value;
            datos.Text = Listar(Convert.ToInt32(idUsuario.Value));
        }
        */

        public string Listar(int idUsuario, string idPabellon, string estadoAgenda)
        {
            try
            {
                GestorDataBusinessAgenda gb = new GestorDataBusinessAgenda();
                StringBuilder tbl = new StringBuilder();
                listaAgenda obj = gb.ListarAgenda(idUsuario);
                if (obj.ListAgenda.Count > 0)
                {
                    tbl.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"display\" width =\"100%\" id=\"datos\">");
                    tbl.Append("<thead><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Servicio</th>");
                    tbl.Append("<th>Pabellón</th>");
                    tbl.Append("<th>Asunto</th>");
                    tbl.Append("<th>Descripción</th>");
                    tbl.Append("<th>Fecha Agendada</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</thead>");
                    tbl.Append("<tfoot><tr>");
                    tbl.Append("<th>Codigo</th>");
                    tbl.Append("<th>Servicio</th>");
                    tbl.Append("<th>Pabellón</th>");
                    tbl.Append("<th>Asunto</th>");
                    tbl.Append("<th>Descripción</th>");
                    tbl.Append("<th>Fecha Agendada</th>");
                    tbl.Append("<th>Estado</th>");
                    tbl.Append("<th>Acciones</th>");
                    tbl.Append("</tfoot>");
                    tbl.Append("<tbody>");


                    foreach (Agenda pdto in obj.ListAgenda)
                    {
                        string identificador = pdto.idAgenda.ToString();
                        string fechaAgendada = pdto.fechaAgenda + " " + pdto.horaAgenda;
                        int idEstado = pdto.estado;

                        if (pdto.idUsuario == idUsuario && (idPabellon == pdto.idPabellon.ToString() || idPabellon == "") && (estadoAgenda == pdto.estado.ToString() || estadoAgenda == ""))
                        {
                            tbl.Append("<tr id=\"fila" + identificador + "\">");
                            tbl.Append("<td>" + identificador + "</td>");
                            tbl.Append("<td>" + pdto.nombreServicio.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.nombrePabellon.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.asunto.ToString() + "</td>");
                            tbl.Append("<td>" + pdto.descripcion.ToString() + "</td>");
                            tbl.Append("<td>" + fechaAgendada + "</td>");
                            tbl.Append("<td id=\"valestado_" + identificador + "\" rel=\"" + idEstado + "\">" + estadoSolicitud[idEstado-1].descEstado + "</td>");
                            tbl.Append("<td class=\"text-left\">");

                            if (idEstado == estadoSolicitud[0].idEstado || idEstado == estadoSolicitud[1].idEstado || idEstado == estadoSolicitud[2].idEstado)
                            {
                                tbl.Append("<button id=\"btnpreparacion_" + identificador + "\" type=\"button\" class=\"btn btn-primary btn-fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoAgenda(" + identificador + "," + estadoSolicitud[1].idEstado.ToString() + ")\"><i class=\"mdi mdi-pipe\">" + estadoSolicitud[1].accionEstado + "</i></button>");
                                tbl.Append("&nbsp;<button id=\"btnlistoentregar_" + identificador + "\" type=\"button\" class=\"btn btn-info btn-fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoAgenda(" + identificador + "," + estadoSolicitud[2].idEstado.ToString() + ")\"><i class=\"mdi mdi-calendar-clock\">" + estadoSolicitud[2].accionEstado + "</i></button>");
                            }
                            if(idEstado == estadoSolicitud[2].idEstado)
                            {
                                tbl.Append("&nbsp;<button id=\"btnentregado_" + identificador + "\" type=\"button\" class=\"btn btn-success btn-fw\" runat=\"server\" OnClick=\"javascript:CambiarEstadoAgenda(" + identificador + "," + estadoSolicitud[3].idEstado.ToString() + ")\"><i class=\"mdi mdi-upload\">" + estadoSolicitud[3].accionEstado + "</i></button>");
                            }
                            else if (idEstado == estadoSolicitud[3].idEstado)
                            {
                                tbl.Append("<button id=\"btnentregado_" + identificador + "\" type=\"button\" class=\"btn btn-success btn-fw\" disabled><i class=\"mdi mdi-upload\">" + estadoSolicitud[3].descEstado + "</i></button>");
                            }

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
                GestorDataBusinessAgenda gb = new GestorDataBusinessAgenda();
                Agenda b = new Agenda();
                Respuesta r = new Respuesta();


                r = gb.CambiarEstadoAgenda(Convert.ToInt32(id), Convert.ToInt16(estado));

                if (r.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + r.descripcion + "); ", true);
                }

                datos.Text = Listar(Convert.ToInt32(id),idPabellon.Value,estadoAgenda.Value);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error verifique:' " + ex.Message.ToString() + "); ", true);
                throw;
            }
        }

        public static string CrearComboPabellon(string nombrecampo, string idPabellon)
        {
            try
            {
                GestorDataBusinessPabellones gb = new GestorDataBusinessPabellones();
                listaPabellones obj = gb.ListarPabellones(0);

                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioPabellon()\" aria-required=\"True\" > ";
                combo = combo + "<option value=\"\">Seleccione</option>";

                if (obj.ListPabellones.Count() > 0)
                {

                    IEnumerable<Pabellones> query = obj.ListPabellones.OrderBy(num => num.nombreServicio);

                    foreach (var l in query)
                    {
                        string t1 = l.idPabellon.ToString();
                        string t2 = l.nombre.ToString();
                        string t3 = l.nombreServicio.ToString();
                        string selected = "selected";
                        if (idPabellon == t1)
                        {
                            combo = combo + "<option value='" + t1 + "' " + selected + ">" + t3 + " - " + t2 + "</option>";
                        }
                        else
                        {
                            combo = combo + "<option value='" + t1 + "'>" + t3 + " - " + t2 + "</option>";
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

        public string CrearComboEstado(string nombrecampo, string estadoAgenda)
        {
            try
            {
                /*
                List<(int idEstado, string descEstado, string accionEstado)> estadoSolicitud = new List<(int, string, string)>()
                        {
                            (?,"En Revisión","En Revisión") ,
                            (?,"En Preparación","En Preparación"),
                            (?,"Listo para Entregar","Listo para Entregar"),
                            (?,"Entregado","Entregar")
                        };
                */
                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioEstado()\" aria-required=\"True\">" +
                    "<option value=''>Seleccione</option>";
                for(int i = 0; i < estadoSolicitud.Count(); i++)
                {
                    if (estadoSolicitud[i].idEstado.ToString() == estadoAgenda)
                    {
                        combo = combo + "<option value='" + estadoSolicitud[i].idEstado + "' selected>" + estadoSolicitud[i].descEstado + "</option>";
                    }
                    else
                    {
                        combo = combo + "<option value='" + estadoSolicitud[i].idEstado + "'>" + estadoSolicitud[i].descEstado + "</option>";
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
    }
}