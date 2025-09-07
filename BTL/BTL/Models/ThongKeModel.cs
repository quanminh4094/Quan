using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    public class ThongKeModel
    {
        private readonly DBHelper _dbHelper;

        public ThongKeModel()
        {
            _dbHelper = new DBHelper();
        }

        public DataTable GetSemesters()
        {
            string query = "SELECT SemesterID, SemesterName FROM Semesters WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable GetCourses()
        {
            string query = "SELECT CourseID, CourseName FROM Courses WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable GetMajors()
        {
            string query = "SELECT MajorID, MajorName FROM Majors WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable GetClasses()
        {
            string query = "SELECT ClassID, ClassName FROM Classes WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable GetStatistics(string semesterID, string courseID, string majorID, string classID)
        {
            string query = @"
                SELECT 
                    S.StudentID, 
                    S.FirstName + ' ' + S.LastName AS FullName,
                    M.MajorName,
                    C.CourseName,
                    SM.SemesterName,
                    CL.ClassName,
                    SUM(SC.ScoreValue * AT.WeightPercentage) / 100 AS AverageScore,
                    CASE 
                        WHEN SUM(SC.ScoreValue * AT.WeightPercentage) / 100 >= 5 THEN N'Đỗ'
                        ELSE N'Trượt'
                    END AS Result
                FROM Students S
                LEFT JOIN Majors M ON S.MajorID = M.MajorID
                LEFT JOIN Enroll E ON S.StudentID = E.StudentID
                LEFT JOIN Classes CL ON E.ClassID = CL.ClassID
                LEFT JOIN Courses C ON CL.CourseID = C.CourseID
                LEFT JOIN Semesters SM ON CL.SemesterID = SM.SemesterID
                LEFT JOIN Scores SC ON S.StudentID = SC.StudentID
                LEFT JOIN AssessmentTypes AT ON SC.AssTypeID = AT.AssTypeID
                WHERE 
                    (@SemesterID IS NULL OR SM.SemesterID = @SemesterID)
                    AND (@CourseID IS NULL OR C.CourseID = @CourseID)
                    AND (@MajorID IS NULL OR M.MajorID = @MajorID)
                    AND (@ClassID IS NULL OR CL.ClassID = @ClassID)
                GROUP BY 
                    S.StudentID, S.FirstName, S.LastName, M.MajorName, 
                    C.CourseName, SM.SemesterName, CL.ClassName";

            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", string.IsNullOrEmpty(semesterID) ? (object)DBNull.Value : semesterID),
                new SqlParameter("@CourseID", string.IsNullOrEmpty(courseID) ? (object)DBNull.Value : courseID),
                new SqlParameter("@MajorID", string.IsNullOrEmpty(majorID) ? (object)DBNull.Value : majorID),
                new SqlParameter("@ClassID", string.IsNullOrEmpty(classID) ? (object)DBNull.Value : classID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        
    }
    }
}
