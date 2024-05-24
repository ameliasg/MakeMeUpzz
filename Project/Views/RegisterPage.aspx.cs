using Project.Controller;
using System;
using System.Web.UI;

namespace Project.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbError.Text = "";
            }
        }

        protected void ReisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string email = EmailTB.Text;
            string password = PasswordTB.Text;
            string confirmPassword = ConfirmPasswordTB.Text;
            string gender = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : null;
            DateTime dob = DobCalendar.SelectedDate;

            UserController userc = new UserController();
            lbError.Text = userc.Register(username, email, gender, password, confirmPassword, dob);

            if (string.IsNullOrEmpty(lbError.Text))
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
        }
    }
}
