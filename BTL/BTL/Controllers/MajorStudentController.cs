using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    public class MajorStudentController
    {

        private readonly MajorStudentModel _model;

        public MajorStudentController()
        {
            _model = new MajorStudentModel();
        }

        public DataTable GetStudentsByMajor(string majorID)
        {
            return _model.GetStudentsByMajor(majorID);
        }

        public DataTable GetStudentCountByMajor()
        {
            return _model.GetStudentCountByMajor();
        }

        public DataTable GetMajors()
        {
            return _model.GetMajors();
        }



    }
}
