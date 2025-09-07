using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BTL.Models


{
    public class CourseClassModel
    {

        private readonly DBHelper _dbHelper;

        public CourseClassModel()
        {
            _dbHelper = new DBHelper();
        }

        public DataTable GetClassesByCourse(string courseID)
        {
            string query = @"
                SELECT 
                    CL.ClassName, 
                    SM.SemesterName, 
                    CO.CourseName, 
                    CO.CourseCredits
                FROM Classes CL
                JOIN Courses CO ON CL.CourseID = CO.CourseID
                JOIN Semesters SM ON CL.SemesterID = SM.SemesterID
                WHERE CO.CourseID = @CourseID AND CL.IsDeleted = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public DataTable GetCourses()
        {
            string query = "SELECT CourseID, CourseName FROM Courses WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }


    }
}
