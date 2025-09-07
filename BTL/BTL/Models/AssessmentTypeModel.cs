using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    internal class AssessmentTypeModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetAssessmentTypes()
        {
            string query = @"SELECT AssTypeID, CourseID, AssTypeName, WeightPercentage, ExamsNo 
                             FROM AssessmentTypes 
                             WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public int AddAssessmentType(int courseID, string assTypeName, float weightPercentage, int examsNo)
        {
            string query = @"INSERT INTO AssessmentTypes (CourseID, AssTypeName, WeightPercentage, ExamsNo) 
                             VALUES (@CourseID, @AssTypeName, @WeightPercentage, @ExamsNo)";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@AssTypeName", assTypeName),
                new SqlParameter("@WeightPercentage", weightPercentage),
                new SqlParameter("@ExamsNo", examsNo)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateAssessmentType(int assTypeID, int courseID, string assTypeName, float weightPercentage, int examsNo)
        {
            string query = @"UPDATE AssessmentTypes 
                             SET CourseID = @CourseID, 
                                 AssTypeName = @AssTypeName, 
                                 WeightPercentage = @WeightPercentage, 
                                 ExamsNo = @ExamsNo
                             WHERE AssTypeID = @AssTypeID";
            SqlParameter[] parameters = {
                new SqlParameter("@AssTypeID", assTypeID),
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@AssTypeName", assTypeName),
                new SqlParameter("@WeightPercentage", weightPercentage),
                new SqlParameter("@ExamsNo", examsNo)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int SoftDeleteAssessmentType(int assTypeID)
        {
            string query = "UPDATE AssessmentTypes SET IsDeleted = 1 WHERE AssTypeID = @AssTypeID";
            SqlParameter[] parameters = {
                new SqlParameter("@AssTypeID", assTypeID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
        public DataTable GetDeletedAssessmentTypes()
        {
            string query = @"SELECT AssTypeID, CourseID, AssTypeName, WeightPercentage, ExamsNo 
                     FROM AssessmentTypes 
                     WHERE IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }

        public int RestoreAssessmentType(int assTypeID)
        {
            string query = "UPDATE AssessmentTypes SET IsDeleted = 0 WHERE AssTypeID = @AssTypeID";
            SqlParameter[] parameters = {
        new SqlParameter("@AssTypeID", assTypeID)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int PermanentlyDeleteAssessmentType(int assTypeID)
        {
            string query = "DELETE FROM AssessmentTypes WHERE AssTypeID = @AssTypeID";
            SqlParameter[] parameters = {
        new SqlParameter("@AssTypeID", assTypeID)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
