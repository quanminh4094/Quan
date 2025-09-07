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
    public partial class DeletedStudentsForm : Form
    {
        private StudentController studentController = new StudentController();

        public DeletedStudentsForm()
        {
            InitializeComponent();
            LoadDeletedStudents();
        }
        // Hàm load danh sách sinh viên đã xóa mềm
        private void LoadDeletedStudents()
        {
            DataTable dt = studentController.GetDeletedStudents();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["StudentID"].Visible = false; // Ẩn cột ID nếu không cần hiển thị
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DeletedStudentsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);

                bool success = studentController.RestoreStudent(studentID);
                if (success)
                {
                    MessageBox.Show("Khôi phục sinh viên thành công!");
                    LoadDeletedStudents(); // Tải lại danh sách sau khi khôi phục
                }
                else
                {
                    MessageBox.Show("Khôi phục sinh viên thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để khôi phục.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hẳn sinh viên này không?",
                                                            "Xác nhận xóa hẳn",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    bool success = studentController.DeletePermanent(studentID);
                    if (success)
                    {
                        MessageBox.Show("Xóa hẳn sinh viên thành công!");
                        LoadDeletedStudents(); // Tải lại danh sách sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn sinh viên thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa hẳn.");
            }
        }
    }
}
