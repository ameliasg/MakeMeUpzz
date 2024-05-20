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
    public partial class UpdateType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            if (IsPostBack == false)
            {
                int TypeID = Convert.ToInt32(Request.QueryString["id"].ToString());
                MakeupType UpdateBrand = mtRepo.GetMakeupTypeByID(TypeID);
                if (UpdateBrand != null)
                {
                    TypeNameTB.Text = UpdateBrand.MakeupTypeName.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/TypePage.aspx");
                }
            }
        }

        protected void UpdateType_Click(object sender, EventArgs e)
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();

            int UpdateID = Convert.ToInt32(Request.QueryString["id"].ToString());
            String TypeName = TypeNameTB.Text;
            mtRepo.UpdateMakeupTypeByID(UpdateID, TypeName);
            Response.Redirect("~/Views/TypePage.aspx");
        }
    }
}