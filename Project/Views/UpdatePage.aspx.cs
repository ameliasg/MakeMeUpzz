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
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupRepository MakeupRepo = new MakeupRepository(); 
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();

            if(IsPostBack == false)
            {
                int MakeupID = Convert.ToInt32(Request.QueryString["id"].ToString());
                Makeup UpdateMakeup = MakeupRepo.GetMakeupByID(MakeupID);
                if(UpdateMakeup != null)
                {
                    MakeupNameTB.Text = UpdateMakeup.MakeupName;
                    MakeupPriceTB.Text = UpdateMakeup.MakeupPrice.ToString();
                    MakeupWeightTB.Text = UpdateMakeup.MakeupWeight.ToString();
                    List<String> MakeupTypeNames = mtRepo.GetMakeupTypeNames();
                    List<String> MakeupBrandNames = mbRepo.GetMakeupBrandName();

                    MakeupTypeDropDown.DataSource = MakeupTypeNames;
                    MakeupTypeDropDown.DataBind();
                    MakeupTypeDropDown.SelectedValue = mtRepo.GetMakeupTypeNameByID(MakeupID);

                    MakeupBrandDropDown.DataSource = MakeupBrandNames;
                    MakeupBrandDropDown.DataBind() ;
                    MakeupBrandDropDown.SelectedValue = mbRepo.GetMakeupBrandNameByID(MakeupID);
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            MakeupRepository MakeupRepo = new MakeupRepository();
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();
            
            int updateID = Convert.ToInt32(Request.QueryString["id"].ToString());
            String MakeupName = MakeupNameTB.Text;
            int MakeupPrice = Convert.ToInt32(MakeupPriceTB.Text);
            int MakeupWeight = Convert.ToInt32(MakeupWeightTB.Text);
            String MakeupTypeName = MakeupTypeDropDown.Text;
            int MakeupTypeID = mtRepo.GetMakeupTypeIDByName(MakeupTypeName);
            String MakeupBrandName = MakeupBrandDropDown.Text;
            int MakeupBrandID = mbRepo.GetMakeupBrandIDByName(MakeupBrandName);
            MakeupRepo.UpdateMakeupByID(updateID, MakeupName, MakeupPrice, MakeupWeight, 
                MakeupTypeID, MakeupBrandID);
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}