using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class CommonFillMethod
    {
        private readonly AppDbContext context;

        public CommonFillMethod(AppDbContext context)
        {
            this.context = context;
        }

        #region FillDropDownList CategoryID
        public List<Category> FillDropDownListCategoryID()
        {
            List<Category> listCategory = new List<Category>();
            listCategory = (from category in context.Categories select category).Where(cat => cat.IsDelete == false).ToList();
            return listCategory;
        }
        #endregion CategoryDropDownList

    }
}
