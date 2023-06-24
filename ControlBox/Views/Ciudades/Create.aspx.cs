using ControlBox.Controllers;
using ControlBox.DB;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox.Views.Ciudades
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Paises_Controller controller = new Paises_Controller();
            controller.Read().ForEach(p =>
            {
                this.drpBox.Items.Add(new ListItem(p.Nombre, p.Pais_id.ToString()));
            });             
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtName.Text))
            {
                Ciudades_Controller controller = new Ciudades_Controller(); 
                TCiudades ciudad = new TCiudades();
                ciudad.Nombre = txtName.Text;   
                ciudad.Pais_id = Convert.ToInt32(drpBox.SelectedValue);
                controller.Create(ciudad);  
                Response.Redirect("~/Views/Ciudades/Ciudades.aspx", false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Ciudades/Ciudades.aspx", false);
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }

        protected void drpBox_SelectedIndexChanged(object sender, EventArgs e)
        {        
            this.txtName.Text = String.Empty;
        }
    }
}