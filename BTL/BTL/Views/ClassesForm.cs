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
    public partial class ClassesForm : Form
    {
        private readonly ClassesController controller = new ClassesController();

        public ClassesForm()
        {
            InitializeComponent();
        }

        private void LoadClasses()
        {
            DataTable classes = controller.GetAllClasses();
            dataGridView1.DataSource = classes;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!dataGridView1.Columns.Contains("MaxStudents"))
            {
                dataGridView1.Columns.Add("MaxStudents", "Số SV tối đa");
            }
        }
        private void LoadComboBoxData()
        {
            DataTable courses = controller.GetAllCourses();
            DataTable semesters = controller.GetAllSemesters();

            cboCourseID.DataSource = courses;
            cboCourseID.DisplayMember = "CourseName"; 
            cboCourseID.ValueMember = "CourseID";    


            cboSemesterID.DataSource = semesters;
            cboSemesterID.DisplayMember = "SemesterName"; 
            cboSemesterID.ValueMember = "SemesterID";    
        }

        private void ClassesForm_Load(object sender, EventArgs e)
        {
            LoadClasses();       
            LoadComboBoxData(); 
            ClearInputs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string className = txtClassName.Text;
            int courseId = (int)cboCourseID.SelectedValue;
            int semesterId = (int)cboSemesterID.SelectedValue;
            int maxStudents = (int)numMaxStudents.Value;

            if (controller.AddNewClass(className, courseId, semesterId, maxStudents))
            {
                MessageBox.Show("Thêm lớp học thành công!");
                LoadClasses();
            }
            else
            {
                MessageBox.Show("Thêm lớp học thất bại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int classId = int.Parse(txtClassID.Text);
            string className = txtClassName.Text;
            int courseId = (int)cboCourseID.SelectedValue;
            int semesterId = (int)cboSemesterID.SelectedValue;
            int maxStudents = (int)numMaxStudents.Value;

            if (controller.UpdateClass(classId, className, courseId, semesterId, maxStudents))
            {
                MessageBox.Show("Cập nhật lớp học thành công!");
                LoadClasses();
            }
            else
            {
                MessageBox.Show("Cập nhật lớp học thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int classId;
            if (int.TryParse(txtClassID.Text, out classId))
            {
                if (controller.DeleteClass(classId))
                {
                    MessageBox.Show("Xóa mềm lớp học thành công!");
                    LoadClasses();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Xóa mềm lớp học thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa mềm!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            LoadClasses();
            LoadComboBoxData();
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtClassID.Clear();        
            txtClassName.Clear();    
            cboCourseID.SelectedIndex = -1;  
            cboSemesterID.SelectedIndex = -1; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["ClassID"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtClassID.Text = row.Cells["ClassID"].Value.ToString();        
                txtClassName.Text = row.Cells["ClassName"].Value.ToString();     
                cboCourseID.Text = row.Cells["CourseName"].Value.ToString();     
                cboSemesterID.Text = row.Cells["SemesterName"].Value.ToString(); 

                if (row.Cells["MaxStudents"].Value != null)
                {
                    numMaxStudents.Value = Convert.ToInt32(row.Cells["MaxStudents"].Value);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
