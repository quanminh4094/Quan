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
    public partial class EnrollForm : Form
    {
        private EnrollController controller = new EnrollController();

        public EnrollForm()
        {
            InitializeComponent();
        }

        private void EnrollForm_Load(object sender, EventArgs e)
        {
            LoadData();
            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            try
            {
                var enrolls = controller.GetEnrolls();
                if (enrolls.Columns.Contains("StudentID"))
                {
                    Console.WriteLine("Cột StudentID tồn tại trong dữ liệu.");
                }
                else
                {
                    Console.WriteLine("Cột StudentID không tồn tại trong dữ liệu.");
                }

                dataGridView1.DataSource = enrolls;

                cboStudents.DataSource = controller.GetStudents();
                cboStudents.DisplayMember = "FullName";
                cboStudents.ValueMember = "StudentID";

                cboClasses.DataSource = controller.GetClasses();
                cboClasses.DisplayMember = "ClassName";
                cboClasses.ValueMember = "ClassID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(cboStudents.SelectedValue);
                int classID = Convert.ToInt32(cboClasses.SelectedValue);

                // Kiểm tra xem lớp đã đầy chưa
                if (controller.IsClassFull(classID))
                {
                    MessageBox.Show("Lớp học này đã đầy, không thể thêm sinh viên!");
                    return;
                }

                int absences = int.Parse(txtAbsences.Text);
                int examsNo = int.Parse(txtExamsNo.Text);
                float examsPoint = float.Parse(txtExamsPoint.Text);
                int examsTimes = int.Parse(txtExamsTimes.Text);

                if (controller.AddEnroll(studentID, classID, absences, examsNo, examsPoint, examsTimes) > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int enrollID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EnrollID"].Value);
                    int studentID = Convert.ToInt32(cboStudents.SelectedValue);
                    int classID = Convert.ToInt32(cboClasses.SelectedValue);
                    int absences = int.Parse(txtAbsences.Text);
                    int examsNo = int.Parse(txtExamsNo.Text);
                    float examsPoint = float.Parse(txtExamsPoint.Text);
                    int examsTimes = int.Parse(txtExamsTimes.Text);

                    int result = controller.UpdateEnroll(enrollID, studentID, classID, absences, examsNo, examsPoint, examsTimes);

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin ghi danh.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int enrollID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EnrollID"].Value);

                    DialogResult confirm = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa ghi danh này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        int result = controller.DeleteEnroll(enrollID);

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa ghi danh.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa sạch các trường nhập liệu
                cboStudents.SelectedIndex = -1;
                cboClasses.SelectedIndex = -1;
                txtAbsences.Clear();
                txtExamsNo.Clear();
                txtExamsPoint.Clear();
                txtExamsTimes.Clear();

                // Làm mới danh sách ghi danh
                LoadData();

                MessageBox.Show("Làm mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới: " + ex.Message);
            }
        }


      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                cboStudents.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value ?? 0);
                cboClasses.SelectedValue = Convert.ToInt32(row.Cells["ClassID"].Value ?? 0);
                txtAbsences.Text = row.Cells["Absences"].Value?.ToString() ?? "0";
                txtExamsNo.Text = row.Cells["ExamsNo"].Value?.ToString() ?? "0";
                txtExamsPoint.Text = row.Cells["ExamsPoint"].Value?.ToString() ?? "0";
                txtExamsTimes.Text = row.Cells["ExamsTimes"].Value?.ToString() ?? "0";
            }

        }
    }
}
