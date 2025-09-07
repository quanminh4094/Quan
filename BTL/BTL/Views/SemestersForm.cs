using BTL.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Views
{
    public partial class SemestersForm : Form
    {
        private SemesterController semesterController = new SemesterController();

        public SemestersForm()
        {
            InitializeComponent();
            LoadActiveSemesters();
        }

        private void LoadActiveSemesters()
        {
            dataGridView1.DataSource = semesterController.GetActiveSemesters();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void SemestersForm_Load(object sender, EventArgs e)
        {
            ClearInputs();
        }
        
        private void ClearInputs()
        {
            txtSemesterID.Clear();
            txtSemesterName.Clear();
            txtYears.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string semesterName = txtSemesterName.Text.Trim();
            string years = txtYears.Text.Trim();

            if (string.IsNullOrEmpty(semesterName) || string.IsNullOrEmpty(years))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (semesterController.AddSemester(semesterName, years) > 0)
            {
                MessageBox.Show("Thêm học kỳ thành công!");
                LoadActiveSemesters();
            }
            else
            {
                MessageBox.Show("Thêm học kỳ thất bại.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int semesterID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SemesterID"].Value);
                string semesterName = txtSemesterName.Text.Trim();
                string years = txtYears.Text.Trim();

                if (string.IsNullOrEmpty(semesterName) || string.IsNullOrEmpty(years))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                if (semesterController.UpdateSemester(semesterID, semesterName, years) > 0)
                {
                    MessageBox.Show("Sửa học kỳ thành công!");
                    LoadActiveSemesters();
                }
                else
                {
                    MessageBox.Show("Sửa học kỳ thất bại.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int semesterID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SemesterID"].Value);
                if (semesterController.SoftDeleteSemester(semesterID) > 0)
                {
                    MessageBox.Show("Xóa mềm thành công!");
                    LoadActiveSemesters();
                }
                else
                {
                    MessageBox.Show("Xóa mềm thất bại.");
                }
            }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Kiểm tra nếu dòng và cột được nhấn là hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Hiển thị giá trị của dòng được chọn vào các TextBox
                txtSemesterID.Text = selectedRow.Cells["SemesterID"].Value?.ToString(); // Thay "SemesterID" bằng tên cột thật
                txtSemesterName.Text = selectedRow.Cells["SemesterName"].Value?.ToString(); // Thay "SemesterName" bằng tên cột thật
                txtYears.Text = selectedRow.Cells["Years"].Value?.ToString(); // Thay "Years" bằng tên cột thật
            }
        }
    }
}
