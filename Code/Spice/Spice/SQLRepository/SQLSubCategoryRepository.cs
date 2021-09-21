using Microsoft.EntityFrameworkCore;
using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.SQLRepository
{
    public class SQLSubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext context;

        public SQLSubCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public SubCategory AddSubCategory(SubCategory subCategory)
        {
            try
            {
                subCategory.IsDelete = false;
                context.SubCategories.Add(subCategory);
                context.SaveChanges();
                return subCategory;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public bool DeleteSubCategory(int id)
        {
            try
            {
                SubCategory subCategory = context.SubCategories.Find(id);

                if (subCategory != null)
                {
                    //context.SubCategories.Remove(subCategory);
                    //context.SaveChanges();

                    subCategory.IsDelete = true;
                    var subCat = context.SubCategories.Attach(subCategory);
                    subCat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public SubCategory EditSubCategory(SubCategory subCategoryChange)
        {
            try
            {
                subCategoryChange.IsDelete = false;
                var subCategory = context.SubCategories.Attach(subCategoryChange);
                subCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return subCategoryChange;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            try
            {
                return context.SubCategories.Include(subCat => subCat.Category).Where(subCat => subCat.IsDelete == false);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public SubCategory GetSubCategoryByID(int id)
        {
            try
            {
                return context.SubCategories.Include(subCat => subCat.Category).Where(subCat => subCat.IsDelete == false).FirstOrDefault(subCat => subCat.SubCategoryID == id);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }
    }
}
