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
    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
        }

        private void studentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.MdiParent = this;  // Đặt form cha cho form con
            studentForm.Show();
        }

        private void deletedStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedStudentsForm deletedStudentForm = new DeletedStudentsForm();
            deletedStudentForm.MdiParent = this;
            deletedStudentForm.Show();
        }

        private void majorFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void majorFormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MajorForm majorForm = new MajorForm();
            majorForm.MdiParent = this;
            majorForm.Show();
        }

        private void deletedMajorFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedMajorForm deletedMajorForm = new DeletedMajorForm();
            deletedMajorForm.MdiParent = this;
            deletedMajorForm.Show();
        }

        private void courseManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void courseCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void semestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void assessmentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreForm scoreForm = new ScoreForm();
            scoreForm.MdiParent = this;
            scoreForm.Show();
        }

        private void enrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollForm enrollForm = new EnrollForm();
                enrollForm.MdiParent = this;
            enrollForm.Show();
        }

        private void semestersFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SemestersForm semestersForm = new SemestersForm();
            semestersForm.MdiParent = this;
            semestersForm.Show();
        }

        private void deletedSemestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedSemesterForm deletedform = new DeletedSemesterForm();
            deletedform.MdiParent = this;
            deletedform.Show();
        }

        private void classesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            classesForm.MdiParent = this;
            classesForm.Show();
        }

        private void deletedClassesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedClassForm deletedform = new DeletedClassForm();
            deletedform.MdiParent = this;
            deletedform.Show();
        }

        private void courseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseManagerForm courseManagerForm = new CourseManagerForm();
            courseManagerForm.MdiParent = this;
            courseManagerForm.Show();
        }

        private void deletedCourseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedCourseForm deletedform = new DeletedCourseForm();
            deletedform.MdiParent = this;
            deletedform.Show();
        }

        private void courseCategoriesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseCategoriesForm courseCategoriesForm = new CourseCategoriesForm();
            courseCategoriesForm.MdiParent = this;
            courseCategoriesForm.Show();
        }

        private void deletedCourseCategoriesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedCourseCategoriesForm deletedform = new DeletedCourseCategoriesForm();
            deletedform.MdiParent = this;
            deletedform.Show();
        }

        private void assessmentTypesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssessmentTypesForm assessmentTypesForm = new AssessmentTypesForm();
            assessmentTypesForm.MdiParent = this;
            assessmentTypesForm.Show();
        }

        private void deletedAssessmentTypesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedAssessmentTypesForm deletedform = new DeletedAssessmentTypesForm();
            deletedform.MdiParent = this;
            deletedform.Show();
        }

        private void recycleBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThongKeChung ThongKeForm = new FrmThongKeChung();
            ThongKeForm.MdiParent = this;  // Đặt form cha cho form con
            ThongKeForm.Show();
        }

        private void studentClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentClass studentclassForm = new FrmStudentClass();
            studentclassForm.MdiParent = this;  // Đặt form cha cho form con
            studentclassForm.Show();
        }

        private void majorStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMajorStudent MajorStudentForm = new FrmMajorStudent();
            MajorStudentForm.MdiParent = this;  // Đặt form cha cho form con
            MajorStudentForm.Show();
        }

        private void courseClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void courseClassToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnShowClasses btnShowClasses = new btnShowClasses();
            btnShowClasses.MdiParent = this;
            btnShowClasses.Show();

        }

        private void semesterClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSemesterClass SemesterClass = new FrmSemesterClass();
            SemesterClass.MdiParent = this;  // Đặt form cha cho form con
            SemesterClass.Show();
        }
    }
}
