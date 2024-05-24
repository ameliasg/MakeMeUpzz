using Project.Controller;
using System;
using System.Web.UI;

namespace Project.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbError.Text = "";
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTB.Text;
            string password = PasswordTB.Text;

            UserController userController = new UserController();
            string errorMsg = userController.Login(email, password, cbRemember);

            if (!string.IsNullOrEmpty(errorMsg))
            {
                lbError.Text = errorMsg;
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void RememberMe_CheckedChanged(object sender, EventArgs e)
        {
            string email = EmailTB.Text;
            string password = PasswordTB.Text;

            UserController userController = new UserController();
            bool isValid = userController.RememberUser(email, password);

            if (!isValid)
            {
                lbError.Text = "Invalid email or password for Remember Me.";
            }
        }
    }
}
