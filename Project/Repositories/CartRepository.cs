using Project.Factories;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class CartRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public void InsertCart(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart cart = CartFactory.Create(CartID, UserID, MakeupID, Quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public List<Cart> GetCarts()
        {
            return db.Carts.ToList();
        }

        public List<Cart> GetCartByUser(int id)
        {
            return (from cart in db.Carts where cart.UserID == id select cart).ToList();
        }

        public void RemoveCartByID(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
        public Cart GetCartByID(int id)
        {
            Cart cart = db.Carts.Find(id);
            return cart;
        }
        public void UpdateCartByID(int id, int UserID, int MakeupID, int Quantity)
        {
            Cart updatecart = GetCartByID(id);
            updatecart.UserID = UserID;
            updatecart.MakeupID = MakeupID;
            updatecart.Quantity = Quantity;
            db.SaveChanges();
        }

        public void ClearCart(int UserID)
        {
            List<Cart> cartsToDelete = db.Carts.Where(c => c.UserID == UserID).ToList();

            db.Carts.RemoveRange(cartsToDelete);
            db.SaveChanges();

        }
    }
}