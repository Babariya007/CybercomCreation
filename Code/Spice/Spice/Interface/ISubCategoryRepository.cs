using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Interface
{
    public interface ISubCategoryRepository
    {
        SubCategory GetSubCategoryByID(int id);
        IEnumerable<SubCategory> GetAllSubCategories();
        SubCategory AddSubCategory(SubCategory subCategory);
        SubCategory EditSubCategory(SubCategory subCategoryChange);
        bool DeleteSubCategory(int id);
    }
}
