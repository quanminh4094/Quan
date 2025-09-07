using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using BTL.Models;

namespace BTL.Controllers
{
    //internal class ThongKeController
    //{
    //}

    public class ThongKeController
    {
        private readonly ThongKeModel _model;

        public ThongKeController()
        {
            _model = new ThongKeModel();
        }

        public DataTable GetSemesters() => _model.GetSemesters();
        public DataTable GetCourses() => _model.GetCourses();
        public DataTable GetMajors() => _model.GetMajors();
        public DataTable GetClasses() => _model.GetClasses();
        public DataTable GetStatistics(string semesterID, string courseID, string majorID, string classID)
        {
            return _model.GetStatistics(semesterID, courseID, majorID, classID);
        }
    }
}
