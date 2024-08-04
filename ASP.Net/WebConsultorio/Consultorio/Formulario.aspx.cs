using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Consultorio
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspNegocio negocio = new EspNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Especialidad> lista = negocio.Listar();
                    Session["listaEspecialidades"] = lista;

                    ddlEspecialidades.DataSource = lista;
                    ddlEspecialidades.DataTextField = "tipo";
                    ddlEspecialidades.DataValueField = "Id";
                    ddlEspecialidades.DataBind();

                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            string url = txtImagen.Text;
            if (!string.IsNullOrEmpty(url))
            {
                Imagen.ImageUrl = url;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Medico nuevo = new Medico();
                MedicosNegocio negocio = new MedicosNegocio();

                List<Medico> listaMedicos = negocio.Listar();
                Medico aux = listaMedicos.Last();

                nuevo.Id = aux.Id + 1;
                nuevo.Datos_personales = new Persona();
                nuevo.Datos_personales.Nombre = txtNombre.Text;
                nuevo.Datos_personales.Apellido = txtApellido.Text;

                if (ddlSexo.Text == "Masculino")
                    nuevo.Datos_personales.Sexo = 'M';
                else nuevo.Datos_personales.Sexo = 'F';

                nuevo.Datos_personales.Nacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.Fecha_ingreso = DateTime.Parse(txtFechaAlta.Text);
                nuevo.Costo_consulta = decimal.Parse(txtCosto.Text);
                nuevo.Imagenes = new List<string>();
                nuevo.Imagenes.Add(txtImagen.Text);
                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.Id = int.Parse(ddlEspecialidades.SelectedValue);
                nuevo.Especialidad.tipo = ddlEspecialidades.Text;

                negocio.Agregar(nuevo);
                Response.Redirect("Default.aspx", false);


            }catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}