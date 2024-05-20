using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class Brand_Page : System.Web.UI.Page
    {
        public List<MakeupBrand> makeupBrand = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();
            if (IsPostBack == false)
            {
                makeupBrand = mbRepo.GetMakeupBrands();
                BrandGridView.DataSource = makeupBrand;
                BrandGridView.DataBind();
            }
        }

        protected void BrandGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = BrandGridView.Rows[e.NewEditIndex];
            int BrandID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateBrand.aspx?id=" + BrandID);
        }

        protected void BrandGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();
            GridViewRow row = BrandGridView.Rows[e.RowIndex];
            int BrandID = Convert.ToInt32(row.Cells[0].Text);
            mbRepo.RemoveMakeupBrandByID(BrandID);
            makeupBrand = mbRepo.GetMakeupBrands();
            BrandGridView.DataSource = makeupBrand;
            BrandGridView.DataBind();
        }
    }
}