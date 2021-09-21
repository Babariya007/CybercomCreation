using Microsoft.EntityFrameworkCore;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.SQLRepository
{
    public class SQLCouponRepository : ICouponRepository
    {
        private readonly AppDbContext context;

        public SQLCouponRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Coupon AddCoupon(Coupon coupon)
        {
            try
            {
                coupon.IsDelete = false;
                context.Coupons.Add(coupon);
                context.SaveChanges();
                return coupon;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public bool DeleteCoupon(int id)
        {
            try
            {
                Coupon coupon = context.Coupons.Find(id);

                if(coupon != null)
                {
                    coupon.IsDelete = true;
                    var cou = context.Coupons.Attach(coupon);
                    cou.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return false;
            }
        }

        public Coupon EditCoupon(Coupon couponChange)
        {
            try
            {
                couponChange.IsDelete = false;
                var cou = context.Coupons.Attach(couponChange);
                cou.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return couponChange;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public IEnumerable<Coupon> GetAllCoupon()
        {
            try
            {
                return context.Coupons.Include(cou => cou.CouponType).Where(cou => cou.IsDelete == false).ToList();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public Coupon GetCouponByID(int id)
        {
            try
            {
                return context.Coupons.Include(cou => cou.CouponType).Where(cou => cou.IsDelete == false).FirstOrDefault(cou => cou.CouponID == id);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }
    }
}
