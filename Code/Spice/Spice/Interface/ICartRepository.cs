using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Interface
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCartList(string UserID);
        Cart AddItemInCart(Cart cart);
        Cart EditCart(Cart cartChange);
        Cart GetByCartID(int id);
        Cart DeleteCart(int id);
        Cart GetManuIdByUserInCart(int ManuItemID, string UserID);
        int CoutCartItem(string UserID);
    }
}
