using Project.Handlers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class CartController
    {
        CartHandler ch = new CartHandler();
        MakeupHandler mh = new MakeupHandler();
        TransactionHeaderHandler thh = new TransactionHeaderHandler();
        TransactionDetailHandler tdh = new TransactionDetailHandler();

        public String QuantityValidation(int qty, int makeupId)
        {
            String errorMsg = null;
            Makeup makeup = new Makeup();
            makeup = mh.SearchMakeup(makeupId);
            System.Diagnostics.Debug.WriteLine(makeup);
            if (qty == -1)
            {
                errorMsg = "Quantity must be filled!";
            }
            return errorMsg;
        }

        public String Insert(int cartId, int userId, int makeupId, int qty)
        {
            String errorMsg = QuantityValidation(qty, makeupId);

            if (errorMsg == null)
            {
                errorMsg = null;
                ch.InsertCart(cartId, userId, makeupId, qty);
            }
            return errorMsg;
        }
        public String ClearCart()
        {
            int userId = Convert.ToInt32(HttpContext.Current.Session["userId"].ToString());

            ch.ClearCart(userId);
            return "";
        }

        public String Checkout()
        {
            int userId = Convert.ToInt32(HttpContext.Current.Session["userId"]);

            List<Cart> carts = ch.GetUserCart(userId);

            if (carts == null || carts.Count == 0)
            {
                return "Cart is empty!";
            }

            DateTime currentDate = DateTime.Now;

            // Define a unique ID for the transaction header if it's not auto-generated
            int id = new Random().Next(1, 1000000); // Replace with appropriate logic

            // Define the status for the transaction
            string status = "Pending"; // Replace with appropriate status

            thh.InsertTransactionHeader(id, userId, currentDate, status);

            int lastId = tdh.GetLastTHID();

            foreach (var cart in carts)
            {
                tdh.InsertTransactionDetail(lastId, cart.MakeupID, (int)cart.Quantity);
            }

            ch.ClearCart(userId);

            return "";
        } 
    }
}