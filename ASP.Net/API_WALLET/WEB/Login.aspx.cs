using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using Dominio;

namespace WEB
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioManager negocio_usuario = new UsuarioManager();
        private Log exLog = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                txtbUsername.BorderColor = default;
                lbErrorUsername.Visible = false;
                txtbPassword.BorderColor = default;
                lbErrorPassword.Visible = false; 
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string input = txtbUsername.Text;
            string password = txtbPassword.Text;
            int id = -1;
            
            try
            {
                if((id = negocio_usuario.ObtenerIdPorUsuario(input)) != -1)
                {
                    if(negocio_usuario.PasswordCheck(id, password))
                    {
                        var user = negocio_usuario.ObenerUsuario(id);
                        Session.Add("Inlog", user);
                        Response.Redirect("AppMenu.aspx", false);

                    }else
                    {
                        txtbPassword.BorderColor = System.Drawing.Color.Red;
                        lbErrorPassword.ForeColor = System.Drawing.Color.Red;
                        lbErrorPassword.Text = "Error: Contraseña incorrecta";
                        lbErrorPassword.Visible = true;
                    }
                }else
                {
                    txtbUsername.BorderColor = System.Drawing.Color.Red;
                    lbErrorUsername.ForeColor = System.Drawing.Color.Red;
                    lbErrorUsername.Text = "Error: Nombre de usuario o email no encontrado";
                    lbErrorUsername.Visible = true;
                }

            }catch (Exception ex)
            {
                string errorMessage = "Error en login: " + ex.Message;
                exLog.Add(errorMessage);
                Session["LastError"] = errorMessage;
                Response.Redirect("Error.aspx");
            }
        }
    }
}