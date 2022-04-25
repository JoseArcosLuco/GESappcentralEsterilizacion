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
    public partial class solicitudagenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmpfecha.Attributes.Add("min", DateTime.Now.ToString("yyyy-MM-dd"));
            comboServicios.Text = CrearComboServicios("cmpidservicio", idServicio.Value);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDataBusinessAgenda gb = new GestorDataBusinessAgenda();
                Agenda b = new Agenda();
                Respuesta r = new Respuesta();
                b.idServicioClinico = Convert.ToInt32(idServicio.Value);
                b.asunto = cmpasunto.Value;
                b.descripcion = cmpdescripcion.Value;
                b.fechaAgenda = cmpfecha.Value;
                b.horaAgenda = cmphora.Value;

                if (b.idServicioClinico != 0)
                {
                    r = gb.Grabar(b);

                    if (r.estado == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + r.descripcion + "!');", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(':) Ingresado Correctamente!');", true);
                        idServicio.Value = "";
                        cmpasunto.Value = "";
                        cmpdescripcion.Value = "";
                        cmpfecha.Value = "";
                        cmphora.Value = "";
                        comboServicios.Text = CrearComboServicios("cmpidservicio", idServicio.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static string CrearComboServicios(string nombrecampo, string idServicio)
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                listaServicioClinico obj = gb.ListarServicioClinico();
                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioServicio()\" aria-required=\"True\" required=\"required\" \"> ";

                combo = combo + "<option value=\"\">Seleccione</option>";
                if (obj.List.Count() > 0)
                {

                    IEnumerable<ServicioClinico> query = obj.List.OrderBy(num => num.nombre);

                    foreach (var l in query)
                    {
                        string t1 = l.idServicioClinico.ToString();
                        string t2 = l.nombre.ToString();
                        string selected = "selected";
                        if (idServicio == t1)
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
    }
}