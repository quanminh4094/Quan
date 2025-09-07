using BTL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Controllers
{
    internal class CourseCategoriesController
    {
        private CourseCategoriesModels categoryModel = new CourseCategoriesModels();

        public DataTable GetActiveCategories()
        {
            return categoryModel.GetActiveCategories();
        }

        public DataTable GetDeletedCategories()
        {
            return categoryModel.GetDeletedCategories();
        }

        public bool DeleteCategory(int categoryID)
        {
            int result = categoryModel.DeleteCategory(categoryID);
            return result > 0;
        }

        public bool RestoreCategory(int categoryID)
        {
            int result = categoryModel.RestoreCategory(categoryID);
            return result > 0;
        }

        public bool PermanentlyDeleteCategory(int categoryID)
        {
            int result = categoryModel.PermanentlyDeleteCategory(categoryID);
            return result > 0;
        }
        public bool AddCategory(string categoryName)
        {
            int result = categoryModel.AddCategory(categoryName);
            return result > 0;
        }

        public bool UpdateCategory(int categoryID, string categoryName)
        {
            int result = categoryModel.UpdateCategory(categoryID, categoryName);
            return result > 0;
        }

        public bool SoftDeleteCategory(int categoryID)
        {
            int result = categoryModel.SoftDeleteCategory(categoryID);
            return result > 0;
        }

    }
}
