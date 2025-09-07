using BTL.Controllers;
using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Views
{
    public partial class DeletedMajorForm : Form
    {
        private MajorController majorController;

        public DeletedMajorForm()
        {
            InitializeComponent();
            majorController = new MajorController();
            LoadDeletedMajors(); // Tải danh sách chuyên ngành đã bị xóa mềm khi form load
        }

        // Hàm để tải các chuyên ngành đã bị xóa mềm
        private void LoadDeletedMajors()
        {
            string query = "SELECT MajorID, MajorName FROM Majors WHERE IsDeleted = 1";
            DBHelper dbHelper = new DBHelper();
            DataTable dt = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dt; // Hiển thị dữ liệu lên DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DeletedMajorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MajorID"].Value);

                string query = "UPDATE Majors SET IsDeleted = 0 WHERE MajorID = @MajorID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MajorID", majorID)
                };

                DBHelper dbHelper = new DBHelper();
                int result = dbHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Khôi phục chuyên ngành thành công!");
                    LoadDeletedMajors(); // Cập nhật lại danh sách chuyên ngành sau khi khôi phục
                }
                else
                {
                    MessageBox.Show("Khôi phục chuyên ngành thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành để khôi phục!");
            }
        }
    }
}
