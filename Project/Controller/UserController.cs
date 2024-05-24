using Project.Handlers;
using Project.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Project.Controller
{
    public class UserController
    {
        private UserHandler userh = new UserHandler();
        private CartHandler carth = new CartHandler();

        public string CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Name must be filled!";
            }
            if (name.Length < 5 || name.Length > 50)
            {
                return "Name must be between 5 and 50 characters!";
            }
            return null;
        }

        public string CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email must be filled!";
            }
            if (userh.CheckEmailUnique(email) != null)
            {
                return "Email must be unique!";
            }
            return null;
        }

        public string CheckGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be selected!";
            }
            return null;
        }

        public string CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Password must be filled!";
            }
            return null;
        }

        public string IsAlphanumeric(string password)
        {
            bool isDigit = password.Any(char.IsDigit);
            bool isLetter = password.Any(char.IsLetter);

            if (!isDigit || !isLetter)
            {
                return "Password must be alphanumeric!";
            }
            return null;
        }

        public string Register(string username, string email, string gender, string password, string confirmPassword, DateTime dob)
        {
            string errorMsg = CheckName(username);

            if (errorMsg == null) errorMsg = CheckEmail(email);
            if (errorMsg == null) errorMsg = CheckGender(gender);
            if (errorMsg == null) errorMsg = CheckPassword(password);
            if (errorMsg == null) errorMsg = IsAlphanumeric(password);
            if (errorMsg == null && password != confirmPassword) errorMsg = "Passwords do not match.";

            if (errorMsg == null)
            {
                int id = new Random().Next();
                userh.InsertUser(id, username, email, dob, gender, "User", password);
                return string.Empty;  // Indicating success
            }
            return errorMsg;  // Returning error message if any validation fails
        }

        public string Login(string email, string password, CheckBox cb)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email must be filled!";
            }
            if (string.IsNullOrEmpty(password))
            {
                return "Password must be filled!";
            }
            if (userh.Login(email, password) == null)
            {
                return "Invalid Credentials!";
            }

            User currentUser = userh.GetUserIDByEmail(email);

            if (cb.Checked)
            {
                HttpCookie userCookie = new HttpCookie("UserData");
                userCookie.Values["email"] = email;
                userCookie.Values["password"] = password;
                userCookie.Expires = DateTime.Now.AddMinutes(1);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }

            HttpContext.Current.Session["userId"] = currentUser.UserID;
            HttpContext.Current.Session["userRole"] = currentUser.UserRole;
            return null;
        }

        public string UpdateUser(string name, string email, string address, string gender, string password, DateTime birthDate)
        {
            string errorMsg = CheckName(name);
            if (errorMsg == null) errorMsg = CheckEmail(email);
            if (errorMsg == null) errorMsg = CheckGender(gender);
            if (errorMsg == null) errorMsg = CheckPassword(password);
            if (errorMsg == null) errorMsg = IsAlphanumeric(password);

            if (errorMsg == null)
            {
                int id = Convert.ToInt32(HttpContext.Current.Session["userId"]);
                userh.UpdateUser(id, name, email, birthDate, gender, "User", password);
            }
            return errorMsg;
        }

        public bool RememberUser(string email, string password)
        {
            return userh.Login(email, password) != null;
        }

        public void Logout()
        {
            HttpContext.Current.Session["userId"] = null;
            HttpContext.Current.Session["userRole"] = null;

            HttpCookie userCookie = HttpContext.Current.Request.Cookies["UserData"];
            if (userCookie != null)
            {
                userCookie.Values["email"] = null;
                userCookie.Values["password"] = null;
                userCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
        }

        public void DeleteAccount(int id)
        {
            carth.ClearCart(id);
            userh.DeleteAccount(id);
            HttpContext.Current.Session["userId"] = null;
            HttpContext.Current.Session["userRole"] = null;
        }
    }
}
