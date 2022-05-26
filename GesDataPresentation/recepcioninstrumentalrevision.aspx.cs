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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaTraza();
            }

            idUsuario.Value = Session["usuarioId"].ToString();

            lblArea.Text = "Área " + nombreBodega.Value + " / Revisión";
            lblCodigoTrazable.Text = idCodigoTrazable.Value;
            lblnombreArticulo.Text = nombreArticulo.Value;

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
                combo = combo + "<th>ID</th><th>Fecha</th><th>Hora</th><th>Nombre Formulario</th><th>Usuario</th><th>Check</th></tr>";
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

        protected void Button_Asignar_Punto_Control_Click(object sender, EventArgs e)
        {
            RecepcionInstrumental r = new RecepcionInstrumental();
            GestorDataBusinessRecepcionInstrumental gdr = new GestorDataBusinessRecepcionInstrumental();
            Respuesta re = new Respuesta();
            try
            {
                r.idUsuario = Convert.ToInt64(idUsuario.Value);
                r.nombreFormulario = nombreBodega.Value;
                r.codigoTrazable = idCodigoTrazable.Value;
                r.puesto = idBodega.Value;

                if (cmpmateriallimpio.Checked){
                    r.materialLimpio = 1;
                }
                else{
                    r.materialLimpio = 0;
                }
                if (cmpmaterialorganicovisible.Checked){
                    r.materialOrganicoVisible = 1;
                }
                else{
                    r.materialOrganicoVisible = 0;
                }
                if (cmpdesarmepiezasensambladas.Checked){
                    r.desarmePiezas = "Si";
                }
                else{
                    r.desarmePiezas = "No";
                }

                r.cantMaterialALavar = Convert.ToInt32(cmpcantidadmaterial.Value);

                r.nombrePaciente = cmpnombrepaciente.Value;
                r.rutPaciente = cmprutpaciente.Value;
                r.observacion = cmpobservaciones.Value;

                r.estadoCheck = 1;

                re = gdr.GrabarRecepcionInstrumental(r);

                if (re.estado == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + re.descripcion + "!');", true);

                    cmpmateriallimpio.Value = "";
                    cmpmaterialorganicovisible.Value = "";
                    cmpdesarmepiezasensambladas.Value = "";
                    cmpcantidadmaterial.Value = "";

                    cmpnombrepaciente.Value = "";
                    cmprutpaciente.Value = "";
                    cmpobservaciones.Value = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Ok Id Revisión:" + re.descripcion + "!');", true);

                    cmpmateriallimpio.Value = "";
                    cmpmaterialorganicovisible.Value = "";
                    cmpdesarmepiezasensambladas.Value = "";
                    cmpcantidadmaterial.Value = "";

                    cmpnombrepaciente.Value = "";
                    cmprutpaciente.Value = "";
                    cmpobservaciones.Value = "";

                    cargaTraza();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + ex.Message.ToString() + "!');", true);
            }
        }
    }
}