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
    public partial class DeletedSemesterForm : Form
    {
        private SemesterController controller = new SemesterController();

        public DeletedSemesterForm()
        {
            InitializeComponent();
            LoadDeletedSemesters();
        }

        private void LoadDeletedSemesters()
        {
            dataGridView1.DataSource = controller.GetDeletedSemesters();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int semesterID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SemesterID"].Value);
                if (controller.RestoreSemester(semesterID) > 0)
                {
                    MessageBox.Show("Khôi phục thành công!");
                    LoadDeletedSemesters();
                }
                else
                {
                    MessageBox.Show("Khôi phục thất bại.");
                }
            }
            }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int semesterID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SemesterID"].Value);

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hẳn học kỳ này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    if (controller.DeleteSemesterPermanently(semesterID) > 0)
                    {
                        MessageBox.Show("Xóa hẳn thành công!");
                        LoadDeletedSemesters();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn thất bại.");
                    }
                }
            }
        }
    }
    }
