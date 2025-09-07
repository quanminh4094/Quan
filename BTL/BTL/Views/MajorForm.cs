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
    public partial class MajorForm : Form
    {
        private MajorController majorController;

        public MajorForm()
        {
            InitializeComponent();
            majorController = new MajorController();
            LoadMajors(); // Tải danh sách chuyên ngành khi form load
        }

        private void MajorForm_Load(object sender, EventArgs e)
        {

        }
        // Hàm để tải dữ liệu chuyên ngành lên DataGridView
        private void LoadMajors()
        {
            DataTable dt = majorController.GetMajors();
            dataGridView1.DataSource = dt; // Hiển thị dữ liệu lên DataGridView

            


            

            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string majorName = txtMajorName.Text.Trim();

            if (!string.IsNullOrEmpty(majorName))
            {
                string query = "INSERT INTO Majors (MajorName) VALUES (@MajorName)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MajorName", majorName)
                };

                DBHelper dbHelper = new DBHelper();
                int result = dbHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm chuyên ngành thành công!");
                    LoadMajors(); // Cập nhật lại danh sách chuyên ngành
                    txtMajorName.Clear(); // Xóa dữ liệu trong textbox sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm chuyên ngành thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên chuyên ngành!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MajorID"].Value);
                string majorName = txtMajorName.Text.Trim();

                if (!string.IsNullOrEmpty(majorName))
                {
                    string query = "UPDATE Majors SET MajorName = @MajorName WHERE MajorID = @MajorID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MajorName", majorName),
                        new SqlParameter("@MajorID", majorID)
                    };

                    DBHelper dbHelper = new DBHelper();
                    int result = dbHelper.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật chuyên ngành thành công!");
                        LoadMajors(); // Cập nhật lại danh sách chuyên ngành
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chuyên ngành thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên chuyên ngành!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành để sửa!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MajorID"].Value);

                string query = "UPDATE Majors SET IsDeleted = 1 WHERE MajorID = @MajorID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MajorID", majorID)
                };

                DBHelper dbHelper = new DBHelper();
                int result = dbHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa chuyên ngành thành công!");
                    LoadMajors(); // Cập nhật lại danh sách chuyên ngành
                }
                else
                {
                    MessageBox.Show("Xóa chuyên ngành thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành để xóa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadMajors();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMajorName.Text = dataGridView1.SelectedRows[0].Cells["MajorName"].Value.ToString();
            }
        }
    }
}
