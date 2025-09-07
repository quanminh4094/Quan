using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    internal class SemesterModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetActiveSemesters()
        {
            string query = "SELECT SemesterID, SemesterName, Years FROM Semesters WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public int AddSemester(string semesterName, string years)
        {
            string query = "INSERT INTO Semesters (SemesterName, Years, IsDeleted) VALUES (@SemesterName, @Years, 0)";
            SqlParameter[] parameters = {
                new SqlParameter("@SemesterName", semesterName),
                new SqlParameter("@Years", years)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateSemester(int semesterID, string semesterName, string years)
        {
            string query = "UPDATE Semesters SET SemesterName = @SemesterName, Years = @Years WHERE SemesterID = @SemesterID AND IsDeleted = 0";
            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", semesterID),
                new SqlParameter("@SemesterName", semesterName),
                new SqlParameter("@Years", years)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }


        public DataTable GetDeletedSemesters()
        {
            string query = "SELECT SemesterID, SemesterName, Years FROM Semesters WHERE IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }

        public int SoftDeleteSemester(int semesterID)
        {
            string query = "UPDATE Semesters SET IsDeleted = 1 WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", semesterID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int RestoreSemester(int semesterID)
        {
            string query = "UPDATE Semesters SET IsDeleted = 0 WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", semesterID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int DeleteSemesterPermanently(int semesterID)
        {
            string query = "DELETE FROM Semesters WHERE SemesterID = @SemesterID";
            SqlParameter[] parameters = {
                new SqlParameter("@SemesterID", semesterID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
