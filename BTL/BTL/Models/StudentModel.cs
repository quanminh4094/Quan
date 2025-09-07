using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.Models
{
    public class StudentModel
    {
        private DBHelper dbHelper = new DBHelper();

        public DataTable GetAllStudents()
        {
            string query = "SELECT * FROM Students WHERE IsDeleted = 0";
            return dbHelper.ExecuteQuery(query);
        }

        public bool AddStudent(string studentCode, string firstName, string lastName, string email, string phone,
                               int majorID, string gender, string address, string identityNumber,
                               string cohort, DateTime dob, string note)
        {
            string query = @"INSERT INTO Students 
                             (StudentCode, FirstName, LastName, Email, Phone, MajorID, Gender, 
                              Addresses, IdentityNumber, Cohort, DOB, Note) 
                             VALUES 
                             (@StudentCode, @FirstName, @LastName, @Email, @Phone, @MajorID, @Gender, 
                              @Addresses, @IdentityNumber, @Cohort, @DOB, @Note)";
            SqlParameter[] parameters = {
                new SqlParameter("@StudentCode", studentCode),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@MajorID", majorID),
                new SqlParameter("@Gender", gender),
                new SqlParameter("@Addresses", address),
                new SqlParameter("@IdentityNumber", identityNumber),
                new SqlParameter("@Cohort", cohort),
                new SqlParameter("@DOB", dob),
                new SqlParameter("@Note", note)
            };
            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateStudent(int studentID, string firstName, string lastName, string email,
                              string phone, int majorID, string gender, string address,
                              string identityNumber, string cohort, DateTime dob, string note)
        {
            string query = @"UPDATE Students 
                         SET FirstName = @FirstName,
                             LastName = @LastName,
                             Email = @Email,
                             Phone = @Phone,
                             MajorID = @MajorID,
                             Gender = @Gender,
                             Addresses = @Address,
                             IdentityNumber = @IdentityNumber,
                             Cohort = @Cohort,
                             DOB = @DOB,
                             Note = @Note
                         WHERE StudentID = @StudentID AND IsDeleted = 0";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@Email", email),
            new SqlParameter("@Phone", phone),
            new SqlParameter("@MajorID", majorID),
            new SqlParameter("@Gender", gender),
            new SqlParameter("@Address", address),
            new SqlParameter("@IdentityNumber", identityNumber),
            new SqlParameter("@Cohort", cohort),
            new SqlParameter("@DOB", dob),
            new SqlParameter("@Note", note),
            new SqlParameter("@StudentID", studentID)
            };

            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool DeleteStudent(int studentID)
        {
            string query = @"UPDATE Students SET IsDeleted = 1 WHERE StudentID = @StudentID";
            SqlParameter[] parameters = {
        new SqlParameter("@StudentID", studentID)
    };
            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
        public DataTable GetDeletedStudents()
        {
            string query = "SELECT StudentID, FirstName, LastName, StudentCode, Email, Phone FROM Students WHERE IsDeleted = 1";
            return dbHelper.ExecuteQuery(query);
        }

        public bool RestoreStudent(int studentID)
        {
            string query = "UPDATE Students SET IsDeleted = 0 WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@StudentID", studentID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters) > 0;
        }
        public int DeletePermanent(int assTypeID)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@StudentID", assTypeID)
            };
            return dbHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
