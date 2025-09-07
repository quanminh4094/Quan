using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    public class SemesterClassController
    {

        private readonly SemesterClassModel _model;

        public SemesterClassController()
        {
            _model = new SemesterClassModel();
        }

        public DataTable GetClassesBySemester(string semesterID)
        {
            return _model.GetClassesBySemester(semesterID);
        }

        public DataTable GetSemesters()
        {
            return _model.GetSemesters();
        }
    }
}
