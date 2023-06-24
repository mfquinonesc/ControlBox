using ControlBox.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBox.Views.Giros
{
    public partial class Giros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Giros_Controller controller = new Giros_Controller();
            this.GridView1.DataSource = controller.ReadAll();
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
            Response.Redirect($"~/Views/Giros/Edit.aspx?id={id}", false);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(((GridView)sender).Rows[e.RowIndex].Cells[2].Text);
            Giros_Controller controller = new Giros_Controller();
            controller.Delete(id);
            Response.Redirect("~/Views/Giros/Giros.aspx", false);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Giros/Create.aspx", false);
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }
    }
}