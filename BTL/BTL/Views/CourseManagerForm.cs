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
    public partial class CourseManagerForm : Form
    {
        private CourseController courseController = new CourseController();
        public CourseManagerForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadCourseCategories();
        }

        private void LoadCourses()
        {
            dataGridView1.DataSource = courseController.GetCourses();
            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadCourseCategories()
        {
            cbbCourseCategory.DataSource = courseController.GetCourseCategories();
            cbbCourseCategory.DisplayMember = "CourseCatName";
            cbbCourseCategory.ValueMember = "CourseCatID";
        }


        private void CourseManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCourseCode.Text;
            string name = txtCourseName.Text;
            int credits = int.Parse(txtCourseCredits.Text);
            int categoryID = (int)cbbCourseCategory.SelectedValue;
            int sessions = int.Parse(txtClassSessions.Text);
            int maxAbsences = int.Parse(txtMaxAllowedAbsences.Text);
            float pointToPass = float.Parse(txtPointToPass.Text);

            if (courseController.AddCourse(code, name, credits, categoryID, sessions, maxAbsences, pointToPass))
            {
                MessageBox.Show("Thêm môn học thành công!");
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Thêm môn học thất bại.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int courseID = int.Parse(txtCourseID.Text);
            string name = txtCourseName.Text;
            int credits = int.Parse(txtCourseCredits.Text);
            int categoryID = (int)cbbCourseCategory.SelectedValue;
            int sessions = int.Parse(txtClassSessions.Text);
            int maxAbsences = int.Parse(txtMaxAllowedAbsences.Text);
            float pointToPass = float.Parse(txtPointToPass.Text);

            if (courseController.UpdateCourse(courseID, name, credits, categoryID, sessions, maxAbsences, pointToPass))
            {
                MessageBox.Show("Cập nhật môn học thành công!");
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Cập nhật môn học thất bại.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int courseID = int.Parse(txtCourseID.Text);

            if (courseController.DeleteCourse(courseID))
            {
                MessageBox.Show("Xóa mềm môn học thành công!");
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Xóa mềm môn học thất bại.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                txtCourseCode.Text = row.Cells["CourseCode"].Value.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
                txtCourseCredits.Text = row.Cells["CourseCredits"].Value.ToString();
                cbbCourseCategory.SelectedValue = row.Cells["CourseCatID"].Value; // Set giá trị cho ComboBox
                txtClassSessions.Text = row.Cells["ClassSessions"].Value.ToString();
                txtMaxAllowedAbsences.Text = row.Cells["MaxAllowedAbsences"].Value.ToString();
                txtPointToPass.Text = row.Cells["PointToPass"].Value.ToString();
            }
        }
        // Hàm để xóa dữ liệu trong các ô nhập liệu
        private void ClearInputs()
        {
            txtCourseID.Clear();
            txtCourseCode.Clear();
            txtCourseName.Clear();
            txtCourseCredits.Clear();
            txtClassSessions.Clear();
            txtMaxAllowedAbsences.Clear();
            txtPointToPass.Clear();

            if (cbbCourseCategory.Items.Count > 0)
            {
                cbbCourseCategory.SelectedIndex = 0; // Chọn giá trị đầu tiên trong ComboBox
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearInputs();  // Xóa dữ liệu trong các ô nhập liệu
            LoadCourses();  // Tải lại danh sách môn học từ cơ sở dữ liệu
        }
    }
}
