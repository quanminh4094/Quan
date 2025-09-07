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
    public partial class FrmMajorStudent : Form
    {

        private readonly MajorStudentController _controller;
        public FrmMajorStudent()
        {
            InitializeComponent();

            _controller = new MajorStudentController();
            LoadMajors();
        }


        // Load danh sách chuyên ngành vào ComboBox
        private void LoadMajors()
        {
            try
            {
                DataTable majors = _controller.GetMajors();
                cbMajors.DataSource = majors;
                cbMajors.DisplayMember = "MajorName";
                cbMajors.ValueMember = "MajorID";
                cbMajors.SelectedIndex = -1; // Không chọn chuyên ngành mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chuyên ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowStudents_Click(object sender, EventArgs e)
        {

            try
            {
                string majorID = cbMajors.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(majorID))
                {
                    MessageBox.Show("Vui lòng chọn một chuyên ngành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable students = _controller.GetStudentsByMajor(majorID);
                dgvStudents.DataSource = students;

                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (students.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sinh viên thuộc chuyên ngành này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable statistics = _controller.GetStudentCountByMajor();
                dgvStatistics.DataSource = statistics;

                // Tự động điều chỉnh kích thước cột để phù hợp với nội dung
                dgvStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (statistics.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
