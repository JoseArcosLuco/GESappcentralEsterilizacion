using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ges.data.model;
using ges.data.business;

namespace ges.data.presentation
{
    public partial class recepcioninstrumentalrevision : System.Web.UI.Page
    {
        string idUsuarioRespaldo = "";
        string idServicioRespaldo = "";
        string idPabellonRespaldo = "";
        string idCodigoTrazableRespaldo = "";
        string nombreArticuloRespaldo = "";
        string idBodegaRespaldo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaTraza();
            }
            idUsuarioRespaldo = idUsuario.Value;
            idServicioRespaldo = idServicio.Value;
            idPabellonRespaldo = idPabellon.Value;
            idCodigoTrazableRespaldo = idCodigoTrazable.Value;
            nombreArticuloRespaldo = nombreArticulo.Value;
            idBodegaRespaldo = idBodega.Value;

            if (idUsuarioRespaldo.Equals(""))
            {
                idUsuarioRespaldo = Session["usuarioId"].ToString();
                idUsuario.Value = idUsuarioRespaldo;
            }

            lblArea.Text = "Área " + nombreBodega.Value + " / Revisión";
            lblCodigoTrazable.Text = idCodigoTrazableRespaldo;
            lblnombreArticulo.Text = nombreArticuloRespaldo;

            comboServicios.Text = CrearComboServicios("cmpidservicio", idServicio.Value);

        }
        public void cargaTraza()
        {
            GestorDataBusinessRecepcionInstrumental gdr = new GestorDataBusinessRecepcionInstrumental();
            listaRecepcionInstrumental lr = new listaRecepcionInstrumental();
            lr = gdr.ListarRevisiones(idCodigoTrazable.Value);
            string divSalida = ListarRevisiones(lr);
            lblTrazabilidad.Text = divSalida;
        }

        public static string ListarRevisiones(listaRecepcionInstrumental result)
        {
            try
            {
                string combo = "";
                combo = combo + "<table class=\"table table-striped table-bordered table-sm\"><tr>";
                combo = combo + "<th>id</th><th>fecha</th><th>hora</th><th>Nombre Formulario</th><th>Usuario</th><th>Check</th></tr>";
                if (result.List.Count() > 0)
                {
                    foreach (var l in result.List)
                    {
                        string t1 = l.idForm.ToString();
                        string t2 = l.fechaReg.ToString();
                        string t3 = l.horaReg.ToString();
                        string t4 = l.nombreFormulario.ToString();
                        string t5 = l.nombreUsuario.ToString();
                        string t6 = l.estadoCheck.ToString();

                        combo = combo + "<tr><td>" + t1 + "</td><td>" + t2 + "</td><td>" + t3 + "</td><td>" + t4 + "</td><td>" + t5 + "</td><td>" + t6 + "</td></tr>";
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

        public static string CrearComboServicios(string nombrecampo, string idServicio)
        {
            try
            {
                GestorDataBusinessServicioClinico gb = new GestorDataBusinessServicioClinico();
                listaServicioClinico obj = gb.ListarServicioClinico();
                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioServicio()\" aria-required=\"True\" required=\"required\" \"> "
                                + "<option value=\"\">Seleccione</option>";

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

        protected void Button_Asignar_Punto_Control_Click(object sender, EventArgs e)
        {
            RecepcionInstrumental r = new RecepcionInstrumental();
            GestorDataBusinessRecepcionInstrumental gdr = new GestorDataBusinessRecepcionInstrumental();
            Respuesta re = new Respuesta();
            try
            {

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + ex.Message.ToString() + "!');", true);
            }
        }
    }
}