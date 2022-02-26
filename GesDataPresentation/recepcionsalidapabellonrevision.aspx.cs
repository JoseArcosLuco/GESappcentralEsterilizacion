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
    public partial class recepcionsalidapabellonrevision : System.Web.UI.Page
    {
        string idServicioRespaldo = "";
        string idServicioPabellonRespaldo = "";
        string idUsuarioRespaldo = "";
        string idCodigoTrazableRespaldo = ""; string nombreArticuloRespaldo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            listaServicioClinico ls = new listaServicioClinico();
            GestorDataBusinessServicioClinico gdbsc = new GestorDataBusinessServicioClinico();

            try
             {
                
                if (!IsPostBack){
                    cargaTraza();
                }
                idServicioRespaldo = idServicio.Value;
                idServicioPabellonRespaldo = idServicioPabellon.Value;
                idUsuarioRespaldo = idUsuario.Value;
                nombreArticuloRespaldo = nombreArticulo.Value;

                
                if (idUsuarioRespaldo.Equals(""))
                {
                    idUsuarioRespaldo = Session["usuarioId"].ToString();
                    idUsuario.Value = idUsuarioRespaldo;
                }
                    

                idCodigoTrazableRespaldo = idCodigoTrazable.Value;

                lblCodigoTrazable.Text = idCodigoTrazableRespaldo;
                lblnombreArticulo.Text = nombreArticuloRespaldo;

                ls = gdbsc.ListarServicioClinico();

                listaServicioClinicoArea lsca = new listaServicioClinicoArea();

                comboservicios.Text = CrearComboServicio("cmpnombreservicio", ls, idServicioRespaldo);
                comboarea.Text = CrearComboServicioArea("cmpnumeropabellon", lsca);

                if (idServicioRespaldo == "")
                    idServicioRespaldo = "0";
                if (acciones.Value == "buscararea")
                    SeleccionarArea(Convert.ToInt64(idServicioRespaldo));


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void cargaTraza() {
            GestorDataBusinessRecepcionSalidaPabellon gdr = new GestorDataBusinessRecepcionSalidaPabellon();
            listaRecepcionSalidaPabellon lrsprev = new listaRecepcionSalidaPabellon();
            lrsprev = gdr.ListarRevisiones(idCodigoTrazable.Value);
            string divSalida = ListarRevisiones(lrsprev);
            lblTrazabilidad.Text = divSalida;
        }
        
        public static string CrearComboServicio(string nombrecampo, listaServicioClinico result, string idServicio)
        {
            try
            {
                string combo = "<select runat=\"server\" id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" onchange=\"CambioServicio()\" aria-required=\"True\" required=\"required\" \"> ";
                combo = combo + "<option value=\"\">Seleccione </option>";
                if (result.List.Count() > 0)
                {
                    foreach (var l in result.List)
                    {
                        string t1 = l.idServicioClinico.ToString();
                        string t2 = l.nombre.ToString();
                        string selected = "selected";
                        if (idServicio == t1)
                        {
                            combo = combo + "<option value='" + t1 + "' " + selected + ">" + t2 + "</option>";
                        }
                        else {
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
        public static string CrearComboServicioArea(string nombrecampo, listaServicioClinicoArea result)
        {
            try
            {
                string combo = "<select id=\"" + nombrecampo + "\" name=\"" + nombrecampo + "\" class=\"form-control\" aria-required=\"True\" required=\"required\">";
                combo = combo + "<option value=\"\">Seleccione </option>";
                if (result.List.Count() > 0)
                {
                    foreach (var l in result.List)
                    {
                        string t1 = l.idServicioClinicoArea.ToString();
                        string t2 = l.nombreServicioClinicoArea.ToString();
                        combo = combo + "<option value=" + t1 + ">" + t2 + "</option>";
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

        public static string ListarRevisiones(listaRecepcionSalidaPabellon result)
        {
            try
            {
                string combo = "";
                combo = combo + "<table class=\"table table-striped table-bordered table-sm\"><tr>";
                combo = combo + "<th>id</th><th>fecha</th><th>hora</th><th>nombre formulario</th><th>usuario</th><th>check</th></tr>";
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

        protected void SeleccionarArea(Int64 id)
        {
            listaServicioClinicoArea ls = new listaServicioClinicoArea();
            GestorDataBusinessServicioClinicoArea gdbsc = new GestorDataBusinessServicioClinicoArea();
            try
            {
                ls = gdbsc.ListarServicioClinicoArea(id);
                comboarea.Text = CrearComboServicioArea("cmpnumeropabellon", ls);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button_Asignar_Punto_Control_Click(object sender, EventArgs e)
        {
            RecepcionSalidaPabellon r = new RecepcionSalidaPabellon();
            GestorDataBusinessRecepcionSalidaPabellon gdr = new GestorDataBusinessRecepcionSalidaPabellon();
            Respuesta re = new Respuesta();
            try
            {
                r.idUsuario = Convert.ToInt64(idUsuarioRespaldo);
                r.nombreFormulario = "Salida Pabellon";
                r.puesto = "1";
                

                r.codigoTrazable = idCodigoTrazable.Value;
                r.idServicioClinico = Convert.ToInt64(idServicio.Value);
                r.idServicioClinicoArea = Convert.ToInt64(idServicioPabellon.Value);
                r.idPabellon = Convert.ToInt64(idServicioPabellon.Value);
                r.nombreArsenalera = cmpnombrearsenalera.Value;
                r.fechaHoraTerminoCirugia = cmphoraterminocirugia.Value;
                r.nombreCirugia = cmpnombrecirugia.Value;
                r.rutPaciente = "";
                r.nombrePaciente = cmpnombrepaciente.Value;
                r.observacion = cmpobs.Value;
                r.estadoCheck = 1;

                re = gdr.GrabarRecepcionSalidaPabellon(r);

                if (re.estado == 1)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Ok Id Revisión:" + re.descripcion + "!');", true);

                    idServicio.Value = "";
                    idServicioPabellon.Value = "";
                    
                    cmpnombrearsenalera.Value = "";
                    cmphoraterminocirugia.Value = "";
                    cmpnombrecirugia.Value = "";
                    cmpnombrepaciente.Value = "";
                    cmpobs.Value = "";

                    cargaTraza();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' se perdio el grabado error estamos verificando!');", true);

                    idServicio.Value ="";
                    idServicioPabellon.Value = "";
                    cmpnombrearsenalera.Value = "";
                    cmphoraterminocirugia.Value = "";
                    cmpnombrecirugia.Value = "";
                    cmpnombrepaciente.Value = "";
                    cmpobs.Value = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error:" + ex.Message.ToString() + "!');", true);
                //throw;
            }
        }

        
    }
}