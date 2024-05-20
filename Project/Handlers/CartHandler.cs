using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class CartHandler
    {
        CartRepository cartRepo = new CartRepository();
        public void InsertCart(int cartId, int userId, int albumId, int qty)
        {
            cartRepo.InsertCart(cartId, userId, albumId, qty);
        }

        public List<Cart> GetUserCart(int userId)
        {
            return cartRepo.GetCartByUser(userId);
        }

        public void ClearCart(int userId)
        {
            cartRepo.ClearCart(userId);
        }

        public void DeleteCart(int userId, int albumId)
        {
            cartRepo.RemoveCartByID(userId);
        }
    }
}