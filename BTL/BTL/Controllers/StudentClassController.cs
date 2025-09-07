using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    public class StudentClassController
    {
        private readonly StudentClassModel _model;

        public StudentClassController()
        {
            _model = new StudentClassModel();
        }

        public DataTable GetClassesByStudent(string studentID)
        {
            return _model.GetClassesByStudent(studentID);
        }

        public DataTable GetCoursesByStudent(string studentID)
        {
            return _model.GetCoursesByStudent(studentID);
        }

        public DataTable GetStudents()
        {
            return _model.GetStudents();
        }
    }
}
