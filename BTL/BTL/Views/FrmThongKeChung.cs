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
    public partial class FrmThongKeChung : Form
    {
        private readonly ThongKeController _controller;

        public FrmThongKeChung()
        {
            InitializeComponent();
            // Khởi tạo controller (không cần chuỗi kết nối trực tiếp)
            _controller = new ThongKeController();

            // Gọi hàm load dữ liệu cho các ComboBox
            LoadComboboxes();
        }




        

            private void btnDanhSach_Click(object sender, EventArgs e)
            {

            string semesterID = cbSemesters.SelectedValue?.ToString();
            string courseID = cbCourses.SelectedValue?.ToString();
            string majorID = cbMajors.SelectedValue?.ToString();
            string classID = cbClasses.SelectedValue?.ToString();

            DataTable result = _controller.GetStatistics(semesterID, courseID, majorID, classID);
            dataGridView1.DataSource = result;

            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void LoadComboboxes()
        {
            try
            {
                // Load dữ liệu kỳ học
                DataTable semesters = _controller.GetSemesters();
                if (semesters.Rows.Count > 0)
                {
                    cbSemesters.DataSource = semesters;
                    cbSemesters.DisplayMember = "SemesterName";
                    cbSemesters.ValueMember = "SemesterID";
                    cbSemesters.SelectedIndex = -1; // Không chọn mặc định
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu kỳ học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Load dữ liệu môn học
                DataTable courses = _controller.GetCourses();
                if (courses.Rows.Count > 0)
                {
                    cbCourses.DataSource = courses;
                    cbCourses.DisplayMember = "CourseName";
                    cbCourses.ValueMember = "CourseID";
                    cbCourses.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Load dữ liệu chuyên ngành
                DataTable majors = _controller.GetMajors();
                if (majors.Rows.Count > 0)
                {
                    cbMajors.DataSource = majors;
                    cbMajors.DisplayMember = "MajorName";
                    cbMajors.ValueMember = "MajorID";
                    cbMajors.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu chuyên ngành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Load dữ liệu lớp học
                DataTable classes = _controller.GetClasses();
                if (classes.Rows.Count > 0)
                {
                    cbClasses.DataSource = classes;
                    cbClasses.DisplayMember = "ClassName";
                    cbClasses.ValueMember = "ClassID";
                    cbClasses.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu lớp học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
