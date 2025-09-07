using BTL.Controllers;
using BTL.Models;
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
    public partial class StudentForm : Form
    {
        private StudentController studentController = new StudentController();
        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
            //LoadCourses();
        }

        // Tải danh sách sinh viên và hiển thị lên DataGridView
        private void LoadStudents()
        {
            dataGridView1.DataSource = studentController.GetStudents();

            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        // Xóa nội dung trên các điều khiển TextBox
        private void ClearForm()
        {
            // Xóa trắng các TextBox
            txtStudentCode.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtIdentityNumber.Clear();
            txtCohort.Clear();
            txtNote.Clear();

            // Reset ComboBox Major và Gender
            if (comboBoxMajor.Items.Count > 0)
            {
                comboBoxMajor.SelectedIndex = -1; // Chọn không có giá trị nào
            }
            if (comboBoxGender.Items.Count > 0)
            {
                comboBoxGender.SelectedIndex = -1;
            }

            // Đặt giá trị mặc định cho DateTimePicker
            dtpDOB.Value = DateTime.Now;

            // Xóa chọn trong DataGridView
            dataGridView1.ClearSelection();
        }
        private void studentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            bool success = studentController.AddStudent(
                txtStudentCode.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtPhone.Text,
                Convert.ToInt32(comboBoxMajor.SelectedValue),
                comboBoxGender.SelectedItem.ToString(),
                txtAddress.Text,
                txtIdentityNumber.Text,
                txtCohort.Text,
                dtpDOB.Value,
                txtNote.Text
            );

            if (success)
            {
                MessageBox.Show("Thêm sinh viên thành công");
                ClearForm();
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Thêm sinh viên thất bại");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);

                // Kiểm tra các giá trị trống
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    comboBoxMajor.SelectedIndex == -1 ||
                    comboBoxGender.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }

                // Gọi phương thức cập nhật
                bool success = studentController.UpdateStudent(
                    studentID,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtEmail.Text,
                    txtPhone.Text,
                    Convert.ToInt32(comboBoxMajor.SelectedValue),
                    comboBoxGender.SelectedItem.ToString(),
                    txtAddress.Text,
                    txtIdentityNumber.Text,
                    txtCohort.Text,
                    dtpDOB.Value,
                    txtNote.Text
                );

                if (success)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công");
                    ClearForm();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên thất bại");
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này không?",
                                                            "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    bool success = studentController.DeleteStudent(studentID);
                    if (success)
                    {
                        MessageBox.Show("Xóa mềm sinh viên thành công.");
                        ClearForm();
                        LoadStudents();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại.");
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int studentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);
            //    dataGridViewCourses.DataSource = studentController.GetStudentCourses(studentID);
            //    dataGridViewCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            comboBoxGender.Items.Add("Nam");
            comboBoxGender.Items.Add("Nữ");
            LoadMajors();
        }
        private void LoadMajors()
        {
            MajorController majorController = new MajorController();
            DataTable dtMajors = majorController.GetMajors();

            // Thiết lập dữ liệu cho ComboBox
            comboBoxMajor.DataSource = dtMajors;
            comboBoxMajor.DisplayMember = "MajorName";  // Tên hiển thị
            comboBoxMajor.ValueMember = "MajorID";      // Giá trị được lưu
            comboBoxMajor.SelectedIndex = -1; // Không chọn giá trị nào mặc định
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox, ComboBox và DateTimePicker
                txtStudentCode.Text = row.Cells["StudentCode"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Addresses"].Value.ToString();
                txtIdentityNumber.Text = row.Cells["IdentityNumber"].Value.ToString();
                txtCohort.Text = row.Cells["Cohort"].Value.ToString();
                txtNote.Text = row.Cells["Note"].Value.ToString();

                // Hiển thị ComboBox MajorID
                comboBoxMajor.SelectedValue = Convert.ToInt32(row.Cells["MajorID"].Value);

                // Hiển thị ComboBox Gender
                string gender = row.Cells["Gender"].Value.ToString();
                comboBoxGender.SelectedItem = gender == "Nam" ? "Nam" : "Nữ";

                // Hiển thị DateTimePicker
                if (DateTime.TryParse(row.Cells["DOB"].Value.ToString(), out DateTime dob))
                {
                    dtpDOB.Value = dob;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
