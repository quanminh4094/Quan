using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    internal class CourseModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetCourses()
        {
            string query = @"SELECT CourseID, CourseCode, CourseName, CourseCredits, 
                                    CourseCatID, ClassSessions, MaxAllowedAbsences, PointToPass 
                             FROM Courses WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetCourseCategories()
        {
            string query = @"SELECT CourseCatID, CourseCatName 
                             FROM CourseCategories 
                             WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }


        public int AddCourse(string courseCode, string courseName, int courseCredits, int courseCatID, int classSessions, int maxAllowedAbsences, float pointToPass)
        {
            string query = @"INSERT INTO Courses (CourseCode, CourseName, CourseCredits, CourseCatID, ClassSessions, MaxAllowedAbsences, PointToPass) 
                             VALUES (@CourseCode, @CourseName, @CourseCredits, @CourseCatID, @ClassSessions, @MaxAllowedAbsences, @PointToPass)";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseCode", courseCode),
                new SqlParameter("@CourseName", courseName),
                new SqlParameter("@CourseCredits", courseCredits),
                new SqlParameter("@CourseCatID", courseCatID),
                new SqlParameter("@ClassSessions", classSessions),
                new SqlParameter("@MaxAllowedAbsences", maxAllowedAbsences),
                new SqlParameter("@PointToPass", pointToPass)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateCourse(int courseID, string courseName, int courseCredits, int courseCatID, int classSessions, int maxAllowedAbsences, float pointToPass)
        {
            string query = @"UPDATE Courses 
                             SET CourseName = @CourseName, CourseCredits = @CourseCredits, 
                                 CourseCatID = @CourseCatID, ClassSessions = @ClassSessions, 
                                 MaxAllowedAbsences = @MaxAllowedAbsences, PointToPass = @PointToPass 
                             WHERE CourseID = @CourseID";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@CourseName", courseName),
                new SqlParameter("@CourseCredits", courseCredits),
                new SqlParameter("@CourseCatID", courseCatID),
                new SqlParameter("@ClassSessions", classSessions),
                new SqlParameter("@MaxAllowedAbsences", maxAllowedAbsences),
                new SqlParameter("@PointToPass", pointToPass)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int DeleteCourse(int courseID)
        {
            string query = "UPDATE Courses SET IsDeleted = 1 WHERE CourseID = @CourseID";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
        public DataTable GetDeletedCourses()
        {
            string query = @"SELECT CourseID, CourseCode, CourseName, CourseCredits, 
                                    CourseCatID, ClassSessions, MaxAllowedAbsences, PointToPass 
                             FROM Courses WHERE IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }

        public int RestoreCourse(int courseID)
        {
            string query = "UPDATE Courses SET IsDeleted = 0 WHERE CourseID = @CourseID";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int PermanentlyDeleteCourse(int courseID)
        {
            string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
            SqlParameter[] parameters = {
                new SqlParameter("@CourseID", courseID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
