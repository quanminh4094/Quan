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
    public partial class DeletedCourseCategoriesForm : Form
    {
        private CourseCategoriesController categoryController = new CourseCategoriesController();

        public DeletedCourseCategoriesForm()
        {
            InitializeComponent();
            LoadDeletedCategories();
        }

        // Load danh sách nhóm loại môn học đã xóa mềm
        private void LoadDeletedCategories()
        {
            dataGridView1.DataSource = categoryController.GetDeletedCategories();
            //dataGridView1.Columns["CourseCatID"].Visible = false; // Ẩn cột ID
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int categoryID = (int)dataGridView1.SelectedRows[0].Cells["CourseCatID"].Value;

                if (categoryController.RestoreCategory(categoryID))
                {
                    MessageBox.Show("Khôi phục thành công!");
                    LoadDeletedCategories();
                }
                else
                {
                    MessageBox.Show("Khôi phục thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm loại môn học để khôi phục.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int categoryID = (int)dataGridView1.SelectedRows[0].Cells["CourseCatID"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hẳn nhóm loại môn học này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (categoryController.PermanentlyDeleteCategory(categoryID))
                    {
                        MessageBox.Show("Xóa hẳn thành công!");
                        LoadDeletedCategories();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm loại môn học để xóa hẳn.");
            }
        }
    }
}
