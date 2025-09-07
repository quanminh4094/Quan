using BTL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Controllers
{
    internal class MajorController
    {
        public DataTable GetMajors()
        {
            MajorModel majorModel = new MajorModel();
            return majorModel.GetMajors();
        }
    }
}
