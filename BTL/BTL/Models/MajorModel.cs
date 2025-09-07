using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    internal class MajorModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetMajors()
        {
            string query = "SELECT MajorID, MajorName FROM Majors WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }
    }
}
