using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ges.data.presentation
{
    public partial class cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ConfigurationManager.AppSettings["modo"]) != 0)
            {
                Session.Abandon();
                Response.Redirect("../login.aspx");
            }else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}