using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    internal class ScoreController
    {
        private ScoreModel model = new ScoreModel();

        public DataTable GetScores()
        {
            return model.GetScores();
        }

        public int AddScore(int studentID, int assTypeID, float scoreValue)
        {
            return model.AddScore(studentID, assTypeID, scoreValue);
        }

        public int UpdateScore(int scoreID, int studentID, int assTypeID, float scoreValue)
        {
            return model.UpdateScore(scoreID, studentID, assTypeID, scoreValue);
        }

        public int DeleteScore(int scoreID)
        {
            return model.DeleteScore(scoreID);
        }

        public DataTable GetStudents()
        {
            return model.GetStudents();
        }

        public DataTable GetAssessmentTypes()
        {
            return model.GetAssessmentTypes();
        }
    }
}
