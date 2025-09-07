using System;
using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    internal class EnrollModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetEnrolls()
        {
            string query = @"
    SELECT e.EnrollID, s.StudentID, s.FirstName + ' ' + s.LastName AS StudentName, 
           c.ClassID, c.ClassName, e.Absences, e.ExamsNo, e.ExamsPoint, e.ExamsTimes
    FROM Enroll e
    JOIN Students s ON e.StudentID = s.StudentID
    JOIN Classes c ON e.ClassID = c.ClassID";

            return dbHelper.ExecuteQuery(query);
        }

        public int AddEnroll(int studentID, int classID, int absences, int examsNo, float examsPoint, int examsTimes)
        {
            string query = @"
                INSERT INTO Enroll (StudentID, ClassID, Absences, ExamsNo, ExamsPoint, ExamsTimes) 
                VALUES (@StudentID, @ClassID, @Absences, @ExamsNo, @ExamsPoint, @ExamsTimes)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@ClassID", classID),
                new SqlParameter("@Absences", absences),
                new SqlParameter("@ExamsNo", examsNo),
                new SqlParameter("@ExamsPoint", examsPoint),
                new SqlParameter("@ExamsTimes", examsTimes)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateEnroll(int enrollID, int studentID, int classID, int absences, int examsNo, float examsPoint, int examsTimes)
        {
            string query = @"
                UPDATE Enroll
                SET StudentID = @StudentID, ClassID = @ClassID, Absences = @Absences, 
                    ExamsNo = @ExamsNo, ExamsPoint = @ExamsPoint, ExamsTimes = @ExamsTimes
                WHERE EnrollID = @EnrollID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EnrollID", enrollID),
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@ClassID", classID),
                new SqlParameter("@Absences", absences),
                new SqlParameter("@ExamsNo", examsNo),
                new SqlParameter("@ExamsPoint", examsPoint),
                new SqlParameter("@ExamsTimes", examsTimes)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int DeleteEnroll(int enrollID)
        {
            string query = "DELETE FROM Enroll WHERE EnrollID = @EnrollID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EnrollID", enrollID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetStudents()
        {
            string query = "SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetClasses()
        {
            string query = "SELECT ClassID, ClassName FROM Classes";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetClassStudentCounts()
        {
            string query = @"
        SELECT c.ClassID, c.ClassName, 
               COUNT(e.EnrollID) AS CurrentStudentCount, 
               c.MaxStudents
        FROM Classes c
        LEFT JOIN Enroll e ON e.ClassID = c.ClassID
        GROUP BY c.ClassID, c.ClassName, c.MaxStudents";
            return dbHelper.ExecuteQuery(query);
        }

    }
}
