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

using BTL.Controllers;

namespace BTL.Views
{
    public partial class FrmStudentClass : Form
    {
        private readonly StudentClassController _controller;
        public FrmStudentClass()
        {
            InitializeComponent();

            _controller = new StudentClassController();
            LoadStudents();
        }


        // Load danh sách sinh viên vào ComboBox
        private void LoadStudents()
        {
            try
            {
                DataTable students = _controller.GetStudents();
                cbStudents.DataSource = students;
                cbStudents.DisplayMember = "FullName";
                cbStudents.ValueMember = "StudentID";
                cbStudents.SelectedIndex = -1; // Không chọn sinh viên mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowClasses_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = cbStudents.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable classes = _controller.GetClassesByStudent(studentID);
                dgvClasses.DataSource = classes;

                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (classes.Rows.Count == 0)
                {
                    MessageBox.Show("Sinh viên này chưa đăng ký lớp học nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowCourses_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = cbStudents.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable courses = _controller.GetCoursesByStudent(studentID);
                dgvCourses.DataSource = courses;

                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (courses.Rows.Count == 0)
                {
                    MessageBox.Show("Sinh viên này chưa học môn nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách môn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
