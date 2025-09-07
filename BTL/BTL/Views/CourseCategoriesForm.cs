using BTL.Controllers;
using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Views
{
    public partial class CourseCategoriesForm : Form
    {
        private CourseCategoriesController categoryController = new CourseCategoriesController();
        public CourseCategoriesForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        // Load danh sách nhóm loại môn học
        private void LoadCategories()
        {
            dataGridView1.DataSource = categoryController.GetActiveCategories();
            //dataGridView1.Columns["CourseCatID"].Visible = false; // Ẩn cột ID
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CourseCategoriesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txtCourseCatName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm loại môn học.");
                return;
            }

            if (categoryController.AddCategory(categoryName))
            {
                MessageBox.Show("Thêm mới thành công!");
                LoadCategories();
                txtCourseCatName.Clear();
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
                int categoryID = (int)dataGridView1.SelectedRows[0].Cells["CourseCatID"].Value;
                string categoryName = txtCourseCatName.Text.Trim();

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm loại môn học.");
                    return;
                }

                if (categoryController.UpdateCategory(categoryID, categoryName))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadCategories();
                    txtCourseCatName.Clear();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm loại môn học để sửa.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int categoryID = (int)dataGridView1.SelectedRows[0].Cells["CourseCatID"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhóm loại môn học này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (categoryController.SoftDeleteCategory(categoryID))
                    {
                        MessageBox.Show("Xóa mềm thành công!");
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mềm thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm loại môn học để xóa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtCourseCatName.Text = dataGridView1.SelectedRows[0].Cells["CourseCatName"].Value.ToString();
            }
        }
    }
}
