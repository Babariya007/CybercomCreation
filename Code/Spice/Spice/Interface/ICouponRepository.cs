using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Interface
{
    public interface ICouponRepository
    {
        Coupon GetCouponByID(int id);
        IEnumerable<Coupon> GetAllCoupon();
        Coupon AddCoupon(Coupon coupon);
        Coupon EditCoupon(Coupon couponChange);
        bool DeleteCoupon(int id);
    }
}
