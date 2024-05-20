using Project.Handlers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Project.Controller
{
    public class UserController
    {
        private UserHandler userh = new UserHandler();
        private CartHandler carth = new CartHandler();

        public String CheckName(String name)
        {
            String errorMsg = null;
            if (name.Length < 5 || name.Length > 50)
            {
                if (name.Length == 0)
                {
                    errorMsg = "Name must be filled!";
                }
                else
                {
                    errorMsg = "Name must be between 5 and 50 characters!";
                }
            }

            return errorMsg;
        }

        public String CheckEmail(String email)
        {
            String errorMsg = null;

            if (email.Length == 0)
            {
                errorMsg = "Email must be filled!";
            }
            else if (userh.checkEmailUnique(email) != null)
            {
                errorMsg = "Email must be unique!";
            }
            return errorMsg;
        }

        public String CheckGender(RadioButton rbMale, RadioButton rbFemale)
        {
            String errorMsg = null;
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                errorMsg = "Gender must be selected!";
            }
            return errorMsg;
        }

        public String checkAddress(String address)
        {
            String errorMsg = null;
            if (address.Length == 0)
            {
                errorMsg = "Address must be filled!";
            }
            else if (!address.EndsWith("Street"))
            {
                errorMsg = "Address must be ends with Street!";
            }
            return errorMsg;
        }

        public String CheckPassword(String password)
        {
            String errorMsg = null;

            if (password.Length == 0)
            {
                errorMsg = "Password must be filled!";
            }

            return errorMsg;
        }

        public String IsAlphanumeric(String password)
        {
            String errorMsg = null;
            bool isDigit = false;
            bool isLetter = false;
            bool isAlphanumeric = false;
            foreach (char c in password)
            {
                if (Char.IsDigit(c))
                {
                    isDigit = true;
                    break;
                }
            }

            if (isDigit == true)
            {
                foreach (char c in password)
                {
                    if (Char.IsLetter(c))
                    {
                        isLetter = true;
                        break;
                    }
                }
            }

            if (isDigit && isLetter)
            {
                isAlphanumeric = true;
            }

            if (!isAlphanumeric)
            {
                errorMsg = "Password must be alphanumeric!";
            }

            return errorMsg;
        }

        public String Register(String name, String email, String address, RadioButton maleBtn, RadioButton femaleBtn, String password)
        {
            String errorMsg = CheckName(name);
            String gender = null;

            if (errorMsg == null)
            {
                errorMsg = CheckEmail(email);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckGender(maleBtn, femaleBtn);
            }
            if (errorMsg == null)
            {
                errorMsg = checkAddress(address);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckPassword(password);
            }
            if (errorMsg == null)
            {
                errorMsg = IsAlphanumeric(password);
            }
            if (errorMsg == null)
            {
                if (maleBtn.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                errorMsg = null;
                userh.InsertUser(name, email, password, gender, address, "User");
            }
            return errorMsg;
        }

        public String Login(String email, String password, CheckBox cb)
        {
            String errorMsg = null;

            if (email.Length == 0)
            {
                errorMsg = "Email must be filled!";
            }
            else if (password.Length == 0)
            {
                errorMsg = "Password must be filled!";
            }
            else if (userh.Login(email, password) == null)
            {
                errorMsg = "Invalid Credentials!";
            }
            else if (errorMsg == null)
            {
                User currentUser = new User();
                currentUser = userh.GetUserIDByEmail(email);

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
            }
            return errorMsg;
        }

        public String doUpdate(String name, String email, String address, RadioButton maleBtn, RadioButton femaleBtn, String password)
        {
            String errorMsg = CheckName(name);
            String gender = null;

            if (errorMsg == null)
            {
                errorMsg = CheckEmail(email);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckGender(maleBtn, femaleBtn);
            }
            if (errorMsg == null)
            {
                errorMsg = checkAddress(address);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckPassword(password);
            }
            if (errorMsg == null)
            {
                errorMsg = IsAlphanumeric(password);
            }
            if (errorMsg == null)
            {
                if (maleBtn.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                errorMsg = null;
                System.Diagnostics.Debug.WriteLine(HttpContext.Current.Session["userId"]);
                int id = Convert.ToInt32(HttpContext.Current.Session["userId"].ToString());
                userh.UpdateUser(id, name, email, password, gender, address);
            }
            return errorMsg;
        }
        public bool doRemember(String email, String password)
        {
            if (userh.Login(email, password) != null)
            {
                return true;
            }
            return false;
        }

        public void logout()
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

        public void deleteAccount(int id)
        {
            carth.ClearCart(id);
            userh.DeleteAccount(id);
            HttpContext.Current.Session["userId"] = null;
            HttpContext.Current.Session["userRole"] = null;
        }
    }
}