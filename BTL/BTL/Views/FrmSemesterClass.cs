using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BTL.Controllers;

namespace BTL.Views
{
    public partial class FrmSemesterClass : Form
    {

        private readonly SemesterClassController _controller;
        public FrmSemesterClass()
        {
            InitializeComponent();

            _controller = new SemesterClassController();
            LoadSemesters();
        }


        // Load danh sách học kỳ vào ComboBox
        private void LoadSemesters()
        {
            try
            {
                DataTable semesters = _controller.GetSemesters();
                cbSemesters.DataSource = semesters;
                cbSemesters.DisplayMember = "SemesterName";
                cbSemesters.ValueMember = "SemesterID";
                cbSemesters.SelectedIndex = -1; // Không chọn học kỳ mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string semesterID = cbSemesters.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(semesterID))
                {
                    MessageBox.Show("Vui lòng chọn một học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable classes = _controller.GetClassesBySemester(semesterID);
                dgvClasses.DataSource = classes;
                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (classes.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lớp học nào trong học kỳ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
