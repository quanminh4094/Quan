using System;
using System.Data;
using System.Linq;
using BTL.Models;

namespace BTL.Controllers
{
    internal class EnrollController
    {
        private EnrollModel model = new EnrollModel();

        public DataTable GetEnrolls()
        {
            return model.GetEnrolls();
        }

        public int AddEnroll(int studentID, int classID, int absences, int examsNo, float examsPoint, int examsTimes)
        {
            return model.AddEnroll(studentID, classID, absences, examsNo, examsPoint, examsTimes);
        }

        public int UpdateEnroll(int enrollID, int studentID, int classID, int absences, int examsNo, float examsPoint, int examsTimes)
        {
            return model.UpdateEnroll(enrollID, studentID, classID, absences, examsNo, examsPoint, examsTimes);
        }

        public int DeleteEnroll(int enrollID)
        {
            return model.DeleteEnroll(enrollID);
        }

        public DataTable GetStudents()
        {
            return model.GetStudents();
        }

        public DataTable GetClasses()
        {
            return model.GetClasses();
        }
        public DataTable GetClassStudentCounts()
        {
            return model.GetClassStudentCounts();
        }
        public bool IsClassFull(int classID)
        {
            DataTable classCounts = model.GetClassStudentCounts();
            DataRow row = classCounts.AsEnumerable().FirstOrDefault(r => r.Field<int>("ClassID") == classID);

            if (row != null)
            {
                int currentStudentCount = row.Field<int>("CurrentStudentCount"); // Đảm bảo tên cột đúng
                int maxStudents = row.Field<int>("MaxStudents");

                return currentStudentCount >= maxStudents;
            }

            return false;
        }

    }
}
