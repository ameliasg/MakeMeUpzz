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
    public partial class UpdateBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();
            if (IsPostBack == false)
            {
                int BrandID = Convert.ToInt32(Request.QueryString["id"].ToString());
                MakeupBrand UpdateBrand = mbRepo.GetMakeupBrandByID(BrandID);
                if( UpdateBrand != null)
                {
                    BrandNameTB.Text = UpdateBrand.MakeupBrandName.ToString();
                    RatingTB.Text = UpdateBrand.MakeupBrandName.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/BrandPage.aspx");
                }
            }

        }

        protected void UpdateBrand_Click(object sender, EventArgs e)
        {
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();

            int UpdateID = Convert.ToInt32(Request.QueryString["id"].ToString());
            String BrandName = BrandNameTB.Text;
            int Rating = Convert.ToInt32(RatingTB.Text);
            mbRepo.UpdateMakeupBrandByID(UpdateID, BrandName, Rating);
            Response.Redirect("~/Views/BrandPage.aspx");
        }
    }
}