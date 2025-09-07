using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    internal class SemesterController
    {
        private SemesterModel model = new SemesterModel();

        public DataTable GetActiveSemesters()
        {
            return model.GetActiveSemesters();
        }
        public int AddSemester(string semesterName, string years)
        {
            return model.AddSemester(semesterName, years);
        }

        public int UpdateSemester(int semesterID, string semesterName, string years)
        {
            return model.UpdateSemester(semesterID, semesterName, years);
        }

        public DataTable GetDeletedSemesters()
        {
            return model.GetDeletedSemesters();
        }

        public int SoftDeleteSemester(int semesterID)
        {
            return model.SoftDeleteSemester(semesterID);
        }

        public int RestoreSemester(int semesterID)
        {
            return model.RestoreSemester(semesterID);
        }

        public int DeleteSemesterPermanently(int semesterID)
        {
            return model.DeleteSemesterPermanently(semesterID);
        }
    }
}
