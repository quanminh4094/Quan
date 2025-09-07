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
    public partial class DeletedCourseForm : Form
    {
        private readonly CourseController courseController = new CourseController();

        public DeletedCourseForm()
        {
            InitializeComponent();
            LoadDeletedCourses();
        }

        // Load danh sách các môn học đã xóa mềm
        private void LoadDeletedCourses()
        {
            dataGridView1.DataSource = courseController.GetDeletedCourses();
            dataGridView1.Columns["CourseID"].Visible = false; // Ẩn cột ID

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int courseID = (int)dataGridView1.SelectedRows[0].Cells["CourseID"].Value;

                if (courseController.RestoreCourse(courseID))
                {
                    MessageBox.Show("Khôi phục môn học thành công!");
                    LoadDeletedCourses();
                }
                else
                {
                    MessageBox.Show("Khôi phục môn học thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học cần khôi phục.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int courseID = (int)dataGridView1.SelectedRows[0].Cells["CourseID"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hẳn môn học này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (courseController.PermanentlyDeleteCourse(courseID))
                    {
                        MessageBox.Show("Xóa hẳn môn học thành công!");
                        LoadDeletedCourses();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn môn học thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa hẳn.");
            }
        }       
        private void DeletedCourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
