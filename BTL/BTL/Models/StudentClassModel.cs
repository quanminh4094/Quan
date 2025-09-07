using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    public class StudentClassModel
    {
        private readonly DBHelper _dbHelper;

        public StudentClassModel()
        {
            _dbHelper = new DBHelper();
        }

        public DataTable GetClassesByStudent(string studentID)
        {
            string query = @"
                SELECT 
                    C.ClassName, 
                    SM.SemesterName, 
                    CO.CourseName, 
                    CO.CourseCredits 
                FROM Enroll E
                JOIN Classes C ON E.ClassID = C.ClassID
                JOIN Semesters SM ON C.SemesterID = SM.SemesterID
                JOIN Courses CO ON C.CourseID = CO.CourseID
                WHERE E.StudentID = @StudentID";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public DataTable GetCoursesByStudent(string studentID)
        {
            string query = @"
                SELECT DISTINCT
                    CO.CourseName, 
                    CO.CourseCredits, 
                    SM.SemesterName, 
                    CASE 
                        WHEN E.ExamsPoint >= 5 THEN N'Hoàn thành'
                        ELSE N'Chưa hoàn thành'
                    END AS Status 
                FROM Enroll E
                JOIN Classes C ON E.ClassID = C.ClassID
                JOIN Semesters SM ON C.SemesterID = SM.SemesterID
                JOIN Courses CO ON C.CourseID = CO.CourseID
                WHERE E.StudentID = @StudentID";

            SqlParameter[] parameters = {
                new SqlParameter("@StudentID", studentID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public DataTable GetStudents()
        {
            string query = "SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }
    }
}
