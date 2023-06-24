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
    public partial class Paises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ciudades_Controller controller = new Ciudades_Controller();
            this.GridView1.DataSource = controller.Read();
            this.GridView1.DataBind();  
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
            Response.Redirect($"~/Views/Paises/Edit.aspx?id={id}", false);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {           
            int id = Convert.ToInt32(((GridView)sender).Rows[e.RowIndex].Cells[2].Text);
            Ciudades_Controller controller = new Ciudades_Controller();
            controller.Delete(id);
            Response.Redirect("~/Views/Paises/Paises.aspx", false);
        }       

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Paises/Create.aspx", false);
        }
    }
}