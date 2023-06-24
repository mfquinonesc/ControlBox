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
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Paises_Controller controller = new Paises_Controller();
            TPaises paises = new TPaises();
            if(!String.IsNullOrEmpty(txtName.Text))
            {
                paises.Nombre = txtName.Text;
                controller.Create(paises);
                Response.Redirect("~/Views/Paises/Paises.aspx", false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Paises/Paises.aspx", false);
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }
    }
}