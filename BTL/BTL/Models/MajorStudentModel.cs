using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BTL.Models
{
    public class MajorStudentModel
    {
        private readonly DBHelper _dbHelper;

        public MajorStudentModel()
        {
            _dbHelper = new DBHelper();
        }

        public DataTable GetStudentsByMajor(string majorID)
        {
            string query = @"
                SELECT 
                    S.StudentID, 
                    S.FirstName + ' ' + S.LastName AS FullName, 
                    S.StudentCode, 
                    S.Email, 
                    S.Phone, 
                    M.MajorName
                FROM Students S
                JOIN Majors M ON S.MajorID = M.MajorID
                WHERE M.MajorID = @MajorID AND S.IsDeleted = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@MajorID", majorID)
            };

            return _dbHelper.ExecuteQuery(query, parameters);
        }

        public DataTable GetStudentCountByMajor()
        {
            string query = @"
                SELECT 
                    M.MajorName,
                    COUNT(S.StudentID) AS StudentCount
                FROM Students S
                JOIN Majors M ON S.MajorID = M.MajorID
                WHERE S.IsDeleted = 0
                GROUP BY M.MajorName";

            return _dbHelper.ExecuteQuery(query);
        }

        public DataTable GetMajors()
        {
            string query = "SELECT MajorID, MajorName FROM Majors WHERE IsDeleted = 0";
            return _dbHelper.ExecuteQuery(query);
        }
    }
}
