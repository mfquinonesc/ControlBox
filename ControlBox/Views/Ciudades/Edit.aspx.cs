using ControlBox.Controllers;
using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox.Views.Ciudades
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Paises_Controller controller = new Paises_Controller();
                    controller.Read().ForEach(p =>
                    {
                        this.drpBox.Items.Add(new ListItem(p.Nombre, p.Pais_id.ToString()));
                    });

                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Ciudades_Controller ciudad_controller = new Ciudades_Controller();
                    TCiudades ciudades = ciudad_controller.Read(id);
                    txtId.Text = ciudades.Ciudad_id.ToString();
                    txtName.Text = ciudades.Nombre;
                    drpBox.SelectedValue = ciudades.Ciudad_id.ToString();                   
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
            Ciudades_Controller controller = new Ciudades_Controller();
            TCiudades ciudad = new TCiudades();
            ciudad.Pais_id = Convert.ToInt32(txtId.Text);
            ciudad.Nombre = txtName.Text;
            controller.Update(ciudad);
            Response.Redirect("~/Views/Ciudades/Ciudades.aspx", false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Ciudades/Ciudades.aspx", false);
        }

        protected void drpBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtId.Text = "0";
            this.txtName.Text = String.Empty;
        }
    }
}