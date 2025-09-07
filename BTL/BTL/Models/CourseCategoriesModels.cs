using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    internal class CourseCategoriesModels
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetActiveCategories()
        {
            string query = @"SELECT CourseCatID, CourseCatName 
                             FROM CourseCategories 
                             WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetDeletedCategories()
        {
            string query = @"SELECT CourseCatID, CourseCatName 
                             FROM CourseCategories 
                             WHERE IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }

        public int DeleteCategory(int categoryID)
        {
            string query = "UPDATE CourseCategories SET IsDeleted = 1 WHERE CourseCatID = @CourseCatID";
            SqlParameter[] parameters = { new SqlParameter("@CourseCatID", categoryID) };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int RestoreCategory(int categoryID)
        {
            string query = "UPDATE CourseCategories SET IsDeleted = 0 WHERE CourseCatID = @CourseCatID";
            SqlParameter[] parameters = { new SqlParameter("@CourseCatID", categoryID) };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int PermanentlyDeleteCategory(int categoryID)
        {
            string query = "DELETE FROM CourseCategories WHERE CourseCatID = @CourseCatID";
            SqlParameter[] parameters = { new SqlParameter("@CourseCatID", categoryID) };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
        public int AddCategory(string categoryName)
        {
            string query = @"INSERT INTO CourseCategories (CourseCatName) VALUES (@CourseCatName)";
            SqlParameter[] parameters = {
        new SqlParameter("@CourseCatName", categoryName)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateCategory(int categoryID, string categoryName)
        {
            string query = @"UPDATE CourseCategories SET CourseCatName = @CourseCatName WHERE CourseCatID = @CourseCatID";
            SqlParameter[] parameters = {
        new SqlParameter("@CourseCatName", categoryName),
        new SqlParameter("@CourseCatID", categoryID)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int SoftDeleteCategory(int categoryID)
        {
            string query = "UPDATE CourseCategories SET IsDeleted = 1 WHERE CourseCatID = @CourseCatID";
            SqlParameter[] parameters = {
        new SqlParameter("@CourseCatID", categoryID)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

    }
}
