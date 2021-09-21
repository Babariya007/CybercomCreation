using Microsoft.EntityFrameworkCore;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.SQLRepository
{
    public class SQLCartRepository : ICartRepository
    {
        private readonly AppDbContext context;

        public SQLCartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Cart AddItemInCart(Cart cart)
        {
            try
            {
                context.Carts.Add(cart);
                context.SaveChanges();
                return cart;
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public int CoutCartItem(string UserID)
        {
            try
            {
                return context.Carts.Where(cart => cart.Id == UserID).Count();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return 0;
            }
        }

        public Cart DeleteCart(int id)
        {
            try
            {
                Cart cart = context.Carts.Find(id);

                if(cart != null)
                {
                    context.Carts.Remove(cart);
                    context.SaveChanges();
                }

                return cart;
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public Cart EditCart(Cart cartChange)
        {
            try
            {
                var cart = context.Carts.Attach(cartChange);
                cart.State = EntityState.Modified;
                context.SaveChanges();

                return cartChange;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public Cart GetByCartID(int id)
        {
            try
            {
                return context.Carts.FirstOrDefault(cart => cart.CartID == id);
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public IEnumerable<Cart> GetCartList(string UserID)
        {
            try
            {
                return context.Carts.Include(cart => cart.ManuItem).Where(cart => cart.Id == UserID).ToList();
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public Cart GetManuIdByUserInCart(int ManuItemID, string UserID)
        {
            try
            {
                return context.Carts.Where(cart => cart.Id == UserID).FirstOrDefault(cart => cart.ManuItemID == ManuItemID);
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }
    }
}
