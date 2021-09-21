using Microsoft.EntityFrameworkCore;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.SQLRepository
{
    public class SQLManuItemRepository : IManuItemRepository
    {
        private readonly AppDbContext context;

        public SQLManuItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ManuItem AddManuItem(ManuItem manuItem)
        {
            try
            {
                manuItem.IsDelete = false;
                context.ManuItems.Add(manuItem);
                context.SaveChanges();
                return manuItem;
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public bool DeleteManuItem(int id)
        {
            try
            {
                ManuItem manuItem = context.ManuItems.Find(id);

                if(manuItem != null)
                {
                    manuItem.IsDelete = true;
                    var manu = context.ManuItems.Attach(manuItem);
                    manu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public ManuItem EditManuItem(ManuItem manuItemChange)
        {
            try
            {
                manuItemChange.IsDelete = false;
                var manu = context.ManuItems.Attach(manuItemChange);
                manu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return manuItemChange;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public IEnumerable<ManuItem> GetAllManuItem()
        {
            try
            {
                return context.ManuItems.Include(mi => mi.Category)
                                        .Include(mi => mi.SubCategory)
                                        .Where(mi => mi.IsDelete == false);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public ManuItem GetManuItemByID(int id)
        {
            try
            {
                return context.ManuItems.Include(mi => mi.Category)
                                        .Include(mi => mi.SubCategory)
                                        .Include(mi => mi.Spicyness)
                                        .Where(mi => mi.IsDelete == false)
                                        .FirstOrDefault(mi => mi.ManuItemID == id);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }
    }
}
