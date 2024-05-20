using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class InsertType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            }
        }
        public int GenerateTypeID()
        {
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            int newID = 0;
            int lastID = mtRepo.GetLastTypeID();
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
            MakeupTypeRepository mtRepo = new MakeupTypeRepository();
            int TypeID = GenerateTypeID();
            String TypeName = TypeNameTB.Text;

            mtRepo.InsertMakeupType(TypeID, TypeName);
            Response.Redirect("~/Views/TypePage.aspx");
        }
    }
}