using ControlBox.Controllers;
using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox.Views.Paises
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Paises_Controller controller = new Paises_Controller();
                    TPaises paises = controller.Read(id);
                    txtId.Text = paises.Pais_id.ToString();
                    txtName.Text = paises.Nombre;
                }
                catch
                {

                }
                
            }
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Paises_Controller controller = new Paises_Controller();
            TPaises paises = new TPaises();
            paises.Pais_id = Convert.ToInt32(txtId.Text);
            paises.Nombre = txtName.Text;
            controller.Update(paises);
            Response.Redirect("~/Views/Paises/Paises.aspx", false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Paises/Paises.aspx", false);
        }
    }
}