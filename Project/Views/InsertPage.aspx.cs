using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class InsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            if (IsPostBack == false)
            {
                List<String> makeupTypeNames = mtRepo.GetMakeupTypeNames();
                MakeupTypeDropDown.DataSource = makeupTypeNames;
                MakeupTypeDropDown.DataBind();
            }

            MakeupBrandRepository mbRepo = new MakeupBrandRepository();
            if (IsPostBack == false)
            {
                List<String> makeupBrandNames = mbRepo.GetMakeupBrandName();
                MakeupBrandDropDown.DataSource = makeupBrandNames;
                MakeupBrandDropDown.DataBind();
            }
        }

        public int GenerateMakeupID()
        {
            MakeupRepository MakeupRepo = new MakeupRepository();
            int newID = 0;
            int lastID = MakeupRepo.GetLastMakeupID();
            if (lastID == null)
            {
                lastID = 1;
            }
            else
            {
                int idNumber = lastID;
                idNumber++;
                newID = idNumber;
            }
            return newID;
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            MakeupRepository MakeupRepo = new MakeupRepository();
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            MakeupBrandRepository mbRepo = new MakeupBrandRepository();

            int MakeupID = GenerateMakeupID();
            String MakeupName = MakeupNameTB.Text;
            int MakeupPrice = Convert.ToInt32(MakeupPriceTB.Text);
            int MakeupWeight = Convert.ToInt32(MakeupWeightTB.Text);
            String MakeupTypeName = MakeupTypeDropDown.Text;
            int MakeupTypeID = mtRepo.GetMakeupTypeIDByName(MakeupTypeName);
            String MakeupBrandName = MakeupBrandDropDown.Text;
            int MakeupBrandID = mbRepo.GetMakeupBrandIDByName(MakeupBrandName);

            MakeupRepo.InsertMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, 
                MakeupBrandID);
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}