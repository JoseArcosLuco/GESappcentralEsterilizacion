using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ges.data.presentation
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreUser;
            string idProy;
            string idPerfil;
            string idTransport;
            try
            {
                


                if (!IsPostBack)
                {
                    if (Convert.ToInt32(ConfigurationManager.AppSettings["modo"]) == 0)
                    {
                        if (Session["usuarioId"] == null)
                        {
                            Session["usuarioId"] = ConfigurationManager.AppSettings["IdUsuario"];
                            Session["usuarioNombre"] = ConfigurationManager.AppSettings["usuarioNombre"];
                            Session["usuarioEmail"] = ConfigurationManager.AppSettings["usuarioEmail"];
                            Session["usuarioPerfil"] = ConfigurationManager.AppSettings["usuarioPerfil"];
                            Session["iaUrl"] = "";
                            Session["urlServicio"] = ConfigurationManager.AppSettings["Desarrollo"];
                            Session["proyectoId"] = ConfigurationManager.AppSettings["Proyecto"];
                            Session["perfilId"] = ConfigurationManager.AppSettings["IdPerfil"];
                        }
                    }



                    if (Request.QueryString.Get("nombreUsuario") == null)
                    {
                        nombreUser = Session["usuarioNombre"].ToString();
                    }
                    else
                    {
                        nombreUser = Request.QueryString.Get("nombreUsuario");
                    }

                    if (Request.QueryString.Get("idProy") == null)
                    {
                        idProy = Session["proyectoid"].ToString();
                    }
                    else
                    {
                        idProy = Request.QueryString.Get("idProy");
                    }
                    if (Request.QueryString.Get("idPerfil") == null)
                    {
                        idPerfil = Session["perfilId"].ToString();
                    }
                    else
                    {
                        idPerfil = Request.QueryString.Get("idPerfil");
                    }
                    if (Request.QueryString.Get("idTransport") == null)
                    {
                        idTransport = Session["usuarioId"].ToString();
                    }
                    else
                    {
                        idTransport = Request.QueryString.Get("idTransport");
                    }

                    lblNombreUsuario.Text = nombreUser;
                    lblNombreUsuarioLeft.Text = nombreUser;
                    Session["usuarioNombre"] = nombreUser;
                    Session["proyectoid"] = idProy;
                    Session["perfilId"] = idPerfil;
                    Session["usuarioId"] = idTransport;

                    //Session["usuarioId"] = "1";

                    if (Session["usuarioId"] == null || Session["usuarioId"].ToString() == "")
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Por su seguridad la session a finalizado! " + Session["usuarioId"].ToString() + "'); ", true);
                        Session.Abandon();
                        Response.Redirect("../login.aspx");
                    }
                    else
                    {
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Hola Nuevamente: " + Session["usuarioNombre"].ToString() + "'); ", true);
                    }
                }
                else
                {
                    lblNombreUsuario.Text = Convert.ToString(Session["usuarioNombre"]);
                    lblNombreUsuarioLeft.Text = Convert.ToString(Session["usuarioNombre"]);
                }




                

                
            }
            catch (Exception ex)
            {
                Console.Error.Write("error:" + ex.Message.ToString());
                //throw;
            }
            
        }
    }
}