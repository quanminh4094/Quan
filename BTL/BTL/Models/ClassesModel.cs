using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    public class ClassesModel
    {
        private readonly DBHelper dbHelper = new DBHelper();

        public DataTable GetClasses()
        {
            string query = "SELECT c.ClassID, c.ClassName, co.CourseName, s.SemesterName, c.MaxStudents " +
               "FROM Classes c " +
               "JOIN Courses co ON c.CourseID = co.CourseID " +
               "JOIN Semesters s ON c.SemesterID = s.SemesterID " +
               "WHERE c.IsDeleted = 0";

            return dbHelper.ExecuteQuery(query);
        }

        public int AddClass(string className, int courseId, int semesterId, int maxStudents)
        {
            string query = "INSERT INTO Classes (ClassName, CourseID, SemesterID, IsDeleted ,MaxStudents) " +
                           "VALUES (@ClassName, @CourseID, @SemesterID, 0 ,@maxStudents )";
            SqlParameter[] parameters = {
                new SqlParameter("@ClassName", className),
                new SqlParameter("@CourseID", courseId),
                new SqlParameter("@SemesterID", semesterId),
                new SqlParameter("@maxStudents", maxStudents)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateClass(int classId, string className, int courseId, int semesterId, int maxStudents)
        {
            string query = "UPDATE Classes " +
                           "SET ClassName = @ClassName, CourseID = @CourseID, SemesterID = @SemesterID, MaxStudents = @MaxStudents " +
                           "WHERE ClassID = @ClassID";
            SqlParameter[] parameters = {
        new SqlParameter("@ClassName", className),
        new SqlParameter("@CourseID", courseId),
        new SqlParameter("@SemesterID", semesterId),
        new SqlParameter("@MaxStudents", maxStudents),
        new SqlParameter("@ClassID", classId)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int DeleteClass(int classId)
        {
            string query = "UPDATE Classes SET IsDeleted = 1 WHERE ClassID = @ClassID";
            SqlParameter[] parameters = {
                new SqlParameter("@ClassID", classId)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
        public DataTable GetCourses()
        {
            string query = "SELECT CourseID, CourseName FROM Courses WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetSemesters()
        {
            string query = "SELECT SemesterID, SemesterName FROM Semesters WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }
        public int RestoreClass(int classId)
        {
            string query = "UPDATE Classes SET IsDeleted = 0 WHERE ClassID = @ClassID";
            SqlParameter[] parameters = {
        new SqlParameter("@ClassID", classId)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int PermanentDeleteClass(int classId)
        {
            string query = "DELETE FROM Classes WHERE ClassID = @ClassID";
            SqlParameter[] parameters = {
        new SqlParameter("@ClassID", classId)
    };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetDeletedClasses()
        {
            string query = "SELECT c.ClassID, c.ClassName, co.CourseName, s.SemesterName " +
                           "FROM Classes c " +
                           "JOIN Courses co ON c.CourseID = co.CourseID " +
                           "JOIN Semesters s ON c.SemesterID = s.SemesterID " +
                           "WHERE c.IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }
        


    }
}
