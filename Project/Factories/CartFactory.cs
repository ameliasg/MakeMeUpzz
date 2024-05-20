using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Factories
{
    public class CartFactory
    {
        public static Cart Create(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart c = new Cart();
            c.CartID = CartID;
            c.UserID = UserID;
            c.MakeupID = MakeupID;
            c.Quantity = Quantity;
            return c;
        }
    }
}