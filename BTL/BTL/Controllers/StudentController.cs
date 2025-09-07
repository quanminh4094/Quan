using BTL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Controllers
{
    public class StudentController
    {
        private StudentModel studentModel = new StudentModel();

        public DataTable GetStudents()
        {
            return studentModel.GetAllStudents();
        }

        public bool AddStudent(string studentCode, string firstName, string lastName, string email, string phone,
                               int majorID, string gender, string address, string identityNumber,
                               string cohort, DateTime dob, string note)
        {
            return studentModel.AddStudent(studentCode, firstName, lastName, email, phone, majorID, gender,
                                           address, identityNumber, cohort, dob, note);
        }

        public bool UpdateStudent(int studentID, string firstName, string lastName, string email, string phone,
                           int majorID, string gender, string address, string identityNumber,
                           string cohort, DateTime dob, string note)
        {
            StudentModel studentModel = new StudentModel();
            return studentModel.UpdateStudent(studentID, firstName, lastName, email, phone, majorID,
                                              gender, address, identityNumber, cohort, dob, note);
        }
        public bool DeleteStudent(int studentID)
        {
            return studentModel.DeleteStudent(studentID);
        }
        public DataTable GetDeletedStudents()
        {
            StudentModel studentModel = new StudentModel();
            return studentModel.GetDeletedStudents();
        }

        public bool RestoreStudent(int studentID)
        {
            StudentModel studentModel = new StudentModel();
            return studentModel.RestoreStudent(studentID);
        }
        public bool DeletePermanent(int studentID)
        {
            return studentModel.DeletePermanent(studentID) > 0;
        }
    }

}
