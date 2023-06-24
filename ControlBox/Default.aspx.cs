using ControlBox.Controllers;
using ControlBox.DB;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Paises_Controller pais_controller = new Paises_Controller();
                pais_controller.Read().ForEach(p =>
                {
                    this.drpBoxPais.Items.Add(new ListItem(p.Nombre, p.Pais_id.ToString()));
                });
                if (drpBoxPais.Items.Count > 0)
                {
                    FilldrpBoxCiudad();
                    int id = Convert.ToInt32(drpBoxCiudad.SelectedValue);
                    LoadTable(id);
                }
            }
            else
            {
                this.GridView1.DataSource = new List<VGiros>();
                this.GridView1.DataBind();
            }
        }

        protected void drpBoxPais_SelectedIndexChanged(object sender, EventArgs e)
        {            
            FilldrpBoxCiudad();           
        }
        protected void drpBoxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(drpBoxCiudad.SelectedValue);
            LoadTable(id);
        }
        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }
        private void LoadTable(int id_ciudad)
        {           
            TCiudades ciudades = new TCiudades();
            ciudades.Ciudad_id = id_ciudad;
            Giros_Controller controller = new Giros_Controller();
            List<VGiros> lst = controller.Read(ciudades);          
            this.GridView1.DataSource = lst;
            this.GridView1.DataBind();
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
        protected void drpBoxCiudad_PreRender(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(drpBoxCiudad.SelectedValue);
                LoadTable(id);
            }
            catch { }           
        }
    }
}