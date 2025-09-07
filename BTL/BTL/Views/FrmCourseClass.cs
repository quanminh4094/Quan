using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BTL.Controllers;

namespace BTL.Views
{
    public partial class btnShowClasses : Form
    {
            private readonly CourseClassController _controller;
        public btnShowClasses()
        {
            InitializeComponent();
            _controller = new CourseClassController();
            LoadCourses();

        }


        // Load danh sách môn học vào ComboBox
        private void LoadCourses()
        {
            try
            {
                DataTable courses = _controller.GetCourses();
                cbCourses.DataSource = courses;
                cbCourses.DisplayMember = "CourseName";
                cbCourses.ValueMember = "CourseID";
                cbCourses.SelectedIndex = -1; // Không chọn môn học mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string courseID = cbCourses.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(courseID))
                {
                    MessageBox.Show("Vui lòng chọn một môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable classes = _controller.GetClassesByCourse(courseID);
                dgvClasses.DataSource = classes;

                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (classes.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lớp nào cho môn học này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
