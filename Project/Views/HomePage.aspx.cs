using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        public List<Makeup> makeups = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupRepository makeupRepo = new MakeupRepository();
            if (IsPostBack == false)
            {
            makeups = makeupRepo.GetMakeups();
            MakeupGridView.DataSource = makeups;
            MakeupGridView.DataBind();
            }
        }

        protected void MakeupGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGridView.Rows[e.NewEditIndex];
            int MakeupID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdatePage.aspx?id="+MakeupID);
        }

        protected void MakeupGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MakeupRepository MakeupRepo = new MakeupRepository();
            GridViewRow row = MakeupGridView.Rows[e.RowIndex];
            int MakeupID = Convert.ToInt32(row.Cells[0].Text);
            MakeupRepo.RemoveMakeupByID(MakeupID);
            makeups = MakeupRepo.GetMakeups();
            MakeupGridView.DataSource = makeups;
            MakeupGridView.DataBind();
        }
    }
}