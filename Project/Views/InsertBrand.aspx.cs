using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class InsertBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MakeupBrandRepository mbRepo = new MakeupBrandRepository();
                //int lastBrandID = repository.GetLastBrandID();

            }
        }
            public int GenerateBrandID()
            {
                MakeupBrandRepository mbRepo = new MakeupBrandRepository();
                int newID = 0;
                int lastID = mbRepo.GetLastBrandID();
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
                MakeupBrandRepository mbRepo = new MakeupBrandRepository();
                int BrandID = GenerateBrandID();
                String BrandName = BrandNameTB.Text;
                int Rating = Convert.ToInt32(BrandRatingTB.Text);

            mbRepo.InsertMakeupBrand(BrandID, BrandName, Rating);
            Response.Redirect("~/Views/BrandPage.aspx");
            }
        }
    }