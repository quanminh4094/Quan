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
    public partial class AssessmentTypesForm : Form
    {
        private AssessmentTypeController assessmentTypeController = new AssessmentTypeController();
        private CourseController courseController = new CourseController(); 
        public AssessmentTypesForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadAssessmentTypes();
        }

        private void LoadCourses()
        {
            cboCourses.DataSource = courseController.GetCourses();
            cboCourses.DisplayMember = "CourseName";
            cboCourses.ValueMember = "CourseID";
        }
        private void LoadAssessmentTypes()
        {
            dataGridView1.DataSource = assessmentTypeController.GetAssessmentTypes();
            //dataGridView1.Columns["AssTypeID"].Visible = false; // Ẩn cột ID
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AssessmentTypesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int courseID = Convert.ToInt32(cboCourses.SelectedValue);
            string assTypeName = txtAssTypeName.Text.Trim();
            float weightPercentage = float.Parse(txtWeightPercentage.Text.Trim());
            int examsNo = int.Parse(txtExamsNo.Text.Trim());

            if (assessmentTypeController.AddAssessmentType(courseID, assTypeName, weightPercentage, examsNo))
            {
                MessageBox.Show("Thêm mới thành công!");
                LoadAssessmentTypes();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int assTypeID = (int)dataGridView1.SelectedRows[0].Cells["AssTypeID"].Value;
                int courseID = Convert.ToInt32(cboCourses.SelectedValue);
                string assTypeName = txtAssTypeName.Text.Trim();
                float weightPercentage = float.Parse(txtWeightPercentage.Text.Trim());
                int examsNo = int.Parse(txtExamsNo.Text.Trim());

                if (assessmentTypeController.UpdateAssessmentType(assTypeID, courseID, assTypeName, weightPercentage, examsNo))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadAssessmentTypes();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại đầu điểm để sửa.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int assTypeID = (int)dataGridView1.SelectedRows[0].Cells["AssTypeID"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa loại đầu điểm này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (assessmentTypeController.SoftDeleteAssessmentType(assTypeID))
                    {
                        MessageBox.Show("Xóa mềm thành công!");
                        LoadAssessmentTypes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại đầu điểm để xóa.");
            }
        }
        private void ClearFields()
        {
            // Xóa nội dung của TextBox và ComboBox
            cboCourses.SelectedIndex = -1; // Clear ComboBox
            txtAssTypeName.Clear();
            txtWeightPercentage.Clear();
            txtExamsNo.Clear();

            // Đặt con trỏ vào TextBox đầu tiên (nếu cần)
            txtAssTypeName.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                cboCourses.Text = row.Cells["CourseID"].Value?.ToString();
                txtAssTypeName.Text = row.Cells["AssTypeName"].Value?.ToString();
                txtWeightPercentage.Text = row.Cells["WeightPercentage"].Value?.ToString();
                txtExamsNo.Text = row.Cells["ExamsNo"].Value?.ToString();
            }
        }
    }
}
