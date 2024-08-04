using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio
{
    public partial class PaginaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).TipoUsuario == Dominio.UserType.ADMIN))
            {
                Session.Add("Error", "No tienes permisos para entrar a esta pantalla, necesitas nivel admin.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}