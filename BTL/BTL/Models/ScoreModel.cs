using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    internal class ScoreModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetScores()
        {
            string query = @"SELECT Scores.ScoreID, 
                            Students.StudentID, 
                            Students.FirstName + ' ' + Students.LastName AS FullName,
                            AssessmentTypes.AssTypeID, 
                            AssessmentTypes.AssTypeName, 
                            Scores.ScoreValue
                     FROM Scores
                     INNER JOIN Students ON Scores.StudentID = Students.StudentID
                     INNER JOIN AssessmentTypes ON Scores.AssTypeID = AssessmentTypes.AssTypeID
                     WHERE Students.IsDeleted = 0 AND AssessmentTypes.IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }


        public int AddScore(int studentID, int assTypeID, float scoreValue)
        {
            string query = @"INSERT INTO Scores (StudentID, AssTypeID, ScoreValue)
                             VALUES (@StudentID, @AssTypeID, @ScoreValue)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@AssTypeID", assTypeID),
                new SqlParameter("@ScoreValue", scoreValue)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int UpdateScore(int scoreID, int studentID, int assTypeID, float scoreValue)
        {
            string query = @"UPDATE Scores
                             SET StudentID = @StudentID, AssTypeID = @AssTypeID, ScoreValue = @ScoreValue
                             WHERE ScoreID = @ScoreID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ScoreID", scoreID),
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@AssTypeID", assTypeID),
                new SqlParameter("@ScoreValue", scoreValue)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int DeleteScore(int scoreID)
        {
            string query = "DELETE FROM Scores WHERE ScoreID = @ScoreID"; 
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ScoreID", scoreID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetStudents()
        {
            string query = @"SELECT StudentID, FirstName + ' ' + LastName AS FullName
                             FROM Students
                             WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public DataTable GetAssessmentTypes()
        {
            string query = @"SELECT AssTypeID, AssTypeName
                             FROM AssessmentTypes
                             WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }
    }
}
