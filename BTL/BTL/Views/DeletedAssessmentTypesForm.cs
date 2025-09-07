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
    public partial class DeletedAssessmentTypesForm : Form
    {
        private AssessmentTypeController assessmentTypeController = new AssessmentTypeController();

        public DeletedAssessmentTypesForm()
        {
            InitializeComponent();
            LoadDeletedAssessmentTypes();
        }

        // Tải danh sách các loại đầu điểm đã bị xóa mềm
        private void LoadDeletedAssessmentTypes()
        {
            dataGridView1.DataSource = assessmentTypeController.GetDeletedAssessmentTypes();
           // dataGridView1.Columns["AssTypeID"].Visible = false; // Ẩn cột ID
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int assTypeID = (int)dataGridView1.SelectedRows[0].Cells["AssTypeID"].Value;

                if (assessmentTypeController.RestoreAssessmentType(assTypeID))
                {
                    MessageBox.Show("Khôi phục thành công!");
                    LoadDeletedAssessmentTypes();
                }
                else
                {
                    MessageBox.Show("Khôi phục thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại đầu điểm để khôi phục.");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int assTypeID = (int)dataGridView1.SelectedRows[0].Cells["AssTypeID"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hẳn loại đầu điểm này? Dữ liệu sẽ không thể khôi phục.",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (assessmentTypeController.PermanentlyDeleteAssessmentType(assTypeID))
                    {
                        MessageBox.Show("Xóa hẳn thành công!");
                        LoadDeletedAssessmentTypes();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại đầu điểm để xóa.");
            }
        }
    }
}
