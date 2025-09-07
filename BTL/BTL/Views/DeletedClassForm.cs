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

    public partial class DeletedClassForm : Form
    {
        private readonly ClassesController controller = new ClassesController();

        public DeletedClassForm()
        {
            InitializeComponent();
            LoadDeletedClasses();
        }

        // Tải danh sách các lớp học đã bị xóa mềm
        private void LoadDeletedClasses()
        {
            dataGridView1.DataSource = controller.GetAllDeletedClasses();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            int classId;
            if (dataGridView1.CurrentRow != null && int.TryParse(dataGridView1.CurrentRow.Cells["ClassID"].Value.ToString(), out classId))
            {
                if (controller.RestoreClass(classId))
                {
                    MessageBox.Show("Khôi phục lớp học thành công!");
                    LoadDeletedClasses();
                }
                else
                {
                    MessageBox.Show("Khôi phục lớp học thất bại!");
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int classId;
            if (dataGridView1.CurrentRow != null && int.TryParse(dataGridView1.CurrentRow.Cells["ClassID"].Value.ToString(), out classId))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hẳn lớp học này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (controller.PermanentDeleteClass(classId))
                    {
                        MessageBox.Show("Xóa hẳn lớp học thành công!");
                        LoadDeletedClasses();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hẳn lớp học thất bại!");
                    }
                }
            }
            }
    }
}
