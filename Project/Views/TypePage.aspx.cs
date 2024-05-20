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
    public partial class TypePage : System.Web.UI.Page
    {
        public List<MakeupType> makeupType = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            if (IsPostBack == false)
            {
                makeupType = mtRepo.GetMakeupTypes();
                TypeGridView.DataSource = makeupType;
                TypeGridView.DataBind();
            }
        }

        protected void TypeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TypeGridView.Rows[e.NewEditIndex];
            int TypeID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateType.aspx?id=" + TypeID);
        }

        protected void TypeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            GridViewRow row = TypeGridView.Rows[e.RowIndex];
            int TypeID = Convert.ToInt32(row.Cells[0].Text);
            mtRepo.RemoveMakeupTypeByID(TypeID);
            makeupType = mtRepo.GetMakeupTypes();
            TypeGridView.DataSource = makeupType;
            TypeGridView.DataBind();
        }
    }
}