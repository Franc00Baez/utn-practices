using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Consultorio
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Medico> ListaMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MedicosNegocio negocio = new MedicosNegocio();
                if (Session["ListaMedicos"] == null)
                {
                    Session.Add("ListaMedicos", negocio.Listar());
                    ListaMedicos = negocio.Listar();
                }
                else
                {
                    Session["ListaMedicos"] = negocio.Listar();
                }
                Repeater.DataSource = Session["ListaMedicos"];
                Repeater.DataBind();
            }
        }

        protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
    }
}