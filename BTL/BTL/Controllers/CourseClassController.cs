using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BTL.Models;

namespace BTL.Controllers
{
    public class CourseClassController
    {
        private readonly CourseClassModel _model;

        public CourseClassController()
        {
            _model = new CourseClassModel();
        }

        public DataTable GetClassesByCourse(string courseID)
        {
            return _model.GetClassesByCourse(courseID);
        }

        public DataTable GetCourses()
        {
            return _model.GetCourses();
        }
    }
}
