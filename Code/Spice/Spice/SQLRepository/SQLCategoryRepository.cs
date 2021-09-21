using Spice.Interface;
using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.SQLRepository
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category AddCategory(Category category)
        {
            try
            {
                category.IsDelete = false;
                context.Categories.Add(category);
                context.SaveChanges();
                return category;
            }
            catch(Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = context.Categories.Find(id);

                if (category != null)
                {
                    //context.Categories.Remove(category);
                    //context.SaveChanges();

                    category.IsDelete = true;
                    var cat = context.Categories.Attach(category);
                    cat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public Category EditCategory(Category categoryChange)
        {
            try
            {
                categoryChange.IsDelete = false;
                var category = context.Categories.Attach(categoryChange);
                category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return categoryChange;
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            try
            {
                return context.Categories.Where(cat => cat.IsDelete == false).ToList();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }

        public Category GetCategoryByID(int id)
        {
            try
            {
                return context.Categories.Where(cat => cat.IsDelete == false).FirstOrDefault(cat => cat.CategoryID == id);
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                return null;
            }
        }
    }
}
