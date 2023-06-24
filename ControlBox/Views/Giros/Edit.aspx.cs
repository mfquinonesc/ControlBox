using ControlBox.Controllers;
using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox.Views.Giros
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Paises_Controller pais_controller = new Paises_Controller();
                    pais_controller.Read().ForEach(p =>
                    {
                        this.drpBoxPais.Items.Add(new ListItem(p.Nombre, p.Pais_id.ToString()));
                    });
                    if (drpBoxPais.Items.Count > 0)
                    {
                        FilldrpBoxCiudad();
                    }
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Giros_Controller controller = new Giros_Controller();
                    VGiros giros = controller.ReadAll(id);
                    txtId.Text = giros.Giro_id.ToString();
                    txtGiro.Text = giros.Recibo;
                    drpBoxPais.SelectedValue = giros.Pais_id.ToString();
                    drpBoxCiudad.SelectedValue = giros.Ciudad_id.ToString();
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

        protected void drpBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilldrpBoxCiudad();
            txtGiro.Text = "";
        }

        protected void drpBoxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {     
            txtGiro.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtGiro.Text))
            {
                if (drpBoxCiudad.Items.Count > 0)
                {
                    Giros_Controller controller = new Giros_Controller();
                    TGiros giros = new TGiros();
                    giros.Ciudad_id = Convert.ToInt32(drpBoxCiudad.SelectedValue);
                    giros.Giro_id = Convert.ToInt32(txtId.Text); 
                    giros.Recibo = txtGiro.Text;
                    controller.Update(giros);
                    Response.Redirect("~/Views/Giros/Giros.aspx", false);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Giros/Giros.aspx", false);
        }
        private void FilldrpBoxCiudad()
        {
            this.drpBoxCiudad.Items.Clear();
            TPaises paises = new TPaises();
            paises.Pais_id = Convert.ToInt32(drpBoxPais.SelectedValue);
            Ciudades_Controller ciudad_controller = new Ciudades_Controller();
            ciudad_controller.Read(paises).ForEach(p =>
            {
                this.drpBoxCiudad.Items.Add(new ListItem(p.Nombre, p.Ciudad_id.ToString()));
            });
        }
    }
}