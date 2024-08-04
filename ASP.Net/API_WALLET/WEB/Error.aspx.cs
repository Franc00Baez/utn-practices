using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LastError"] != null)
                {
                    ltlErrorMessage.Text = "<pre>" + Session["LastError"].ToString() + "</pre>";
                    Session["LastError"] = null; // Limpiar el error después de mostrarlo
                }
                else
                {
                    ltlErrorMessage.Text = "<p>No se encontró información del error.</p>";
                }
            }
        }
    }
}