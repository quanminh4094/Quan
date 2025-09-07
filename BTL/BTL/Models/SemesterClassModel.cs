using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    public class SemesterClassModel
    {
        private readonly DBHelper _dbHelper;  

        public SemesterClassModel()
        {
            _dbHelper = new DBHelper();
        }

        public DataTable GetClassesBySemester(string semesterID)
        {
            string query = @"
                SELECT 
                    C.ClassName, 
                    CO.CourseName, 
                    SM.SemesterName, 
                    CO.CourseCredits
                FROM Classes C
                JOIN Courses CO ON C.CourseID = CO.CourseID
                JOIN Semesters SM ON C.SemesterID = SM.SemesterID
                WHERE SM.SemesterID = @SemesterID AND C.IsDeleted = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", semesterID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public DataTable GetSemesters()
        {
            string query = "SELECT SemesterID, SemesterName FROM Semesters WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }

    }
}
