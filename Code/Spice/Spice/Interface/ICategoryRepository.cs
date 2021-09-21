using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Interface
{
    public interface ICategoryRepository
    {
        Category GetCategoryByID(int id);
        IEnumerable<Category> GetAllCategory();
        Category AddCategory(Category category);
        Category EditCategory(Category categoryChange);
        bool DeleteCategory(int id);
    }
}
