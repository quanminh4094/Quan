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
    public partial class ScoreForm : Form
    {
        private ScoreController controller = new ScoreController();

        public ScoreForm()
        {
            InitializeComponent();
        }

        private void ScoreForm_Load(object sender, EventArgs e)
        {
            LoadData();
            // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            try
            {
                // Nạp danh sách điểm vào DataGridView
                dataGridView1.DataSource = controller.GetScores();

                // Nạp danh sách sinh viên vào ComboBox
                cboStudents.DataSource = controller.GetStudents();
                cboStudents.DisplayMember = "FullName";
                cboStudents.ValueMember = "StudentID";

                // Nạp danh sách loại đầu điểm vào ComboBox
                cboAssessmentTypes.DataSource = controller.GetAssessmentTypes();
                cboAssessmentTypes.DisplayMember = "AssTypeName";
                cboAssessmentTypes.ValueMember = "AssTypeID";
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
                int assTypeID = Convert.ToInt32(cboAssessmentTypes.SelectedValue);
                float scoreValue = float.Parse(txtScoreValue.Text);

                int result = controller.AddScore(studentID, assTypeID, scoreValue);
                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể thêm điểm.");
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
                int scoreID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ScoreID"].Value);
                int studentID = Convert.ToInt32(cboStudents.SelectedValue);
                int assTypeID = Convert.ToInt32(cboAssessmentTypes.SelectedValue);
                float scoreValue = float.Parse(txtScoreValue.Text);

                int result = controller.UpdateScore(scoreID, studentID, assTypeID, scoreValue);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật điểm.");
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
                int scoreID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ScoreID"].Value);

                int result = controller.DeleteScore(scoreID);
                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa điểm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cboStudents.SelectedValue = dataGridView1.CurrentRow.Cells["StudentID"].Value;
                cboAssessmentTypes.SelectedValue = dataGridView1.CurrentRow.Cells["AssTypeID"].Value; // Đảm bảo cột tồn tại
                txtScoreValue.Text = dataGridView1.CurrentRow.Cells["ScoreValue"].Value.ToString();
            }
        }
    }
}
