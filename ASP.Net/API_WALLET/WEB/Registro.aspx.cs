using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Helpers;
using Negocio;

namespace WEB
{
    public partial class Registro : System.Web.UI.Page
    {
        private UsuarioManager negocio_usuario = new UsuarioManager();
        private Log exLog = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                txtbUserName.BorderColor = default;
                txtbEmail.BorderColor = default;
                lblErrorUsername.Visible = false;
                lblErrorEmail.Visible = false;

            }
        }

        private bool ValidacionDeCampos()
        {
                string username = string.IsNullOrEmpty(txtbUserName.Text) != true ? txtbUserName.Text : null;
                string email = string.IsNullOrEmpty(txtbEmail.Text) != true ? txtbEmail.Text : null;
                string password = txtbPassword.Text;
                bool bandera = true;
            try
            {
                if(negocio_usuario.UsuarioExiste(username))
                {
                    txtbUserName.BorderColor = System.Drawing.Color.Red;
                    lblErrorUsername.Text = "Error: El nombre de usuario " + username + " ya esta en uso.";
                    lblErrorUsername.Visible = true;
                    bandera = false;
                }

                if(negocio_usuario.EmailExiste(email))
                {
                    txtbEmail.BorderColor = System.Drawing.Color.Red;
                    lblErrorEmail.Text = "Error: Ya existe una cuenta con este email.";
                    lblErrorEmail.Visible = true;
                    bandera = false;
                }

            }catch (Exception ex)
            {
                string errorMessage = "Error en Validacion de campos: " + ex.Message;
                exLog.Add(errorMessage);
                return false;
            }
                return bandera;
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidacionDeCampos())
                {
                    Usuario user = new Usuario
                    {
                        nombre = txtbUserName.Text,
                        email = txtbEmail.Text,
                        pass_hash = HashService.HashPassword(txtbPassword.Text)
                    };

                    if (negocio_usuario.RegistrarNuevo(user))
                    {
                        Response.Redirect("RegistroExitoso.aspx", false);
                    }else
                    {
                        lblErrorGeneral.Text = "Error: No pudimos registrarte, intentelo de nuevo o reporte este error al admin.";
                        lblErrorGeneral.Visible = true;
                    }
                }
            }catch (Exception ex)
            {
                Session["LastError"] = "btnRegister_Click: " + ex.Message;
                Response.Redirect("Error.aspx");
            }
        }
    }
}