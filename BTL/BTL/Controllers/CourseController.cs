using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    internal class CourseController
    {
        private CourseModel courseModel = new CourseModel();

        public DataTable GetCourses()
        {
            return courseModel.GetCourses();
        }

        public DataTable GetCourseCategories()
        {
            return courseModel.GetCourseCategories();
        }

        public bool AddCourse(string courseCode, string courseName, int courseCredits, int courseCatID, int classSessions, int maxAllowedAbsences, float pointToPass)
        {
            int result = courseModel.AddCourse(courseCode, courseName, courseCredits, courseCatID, classSessions, maxAllowedAbsences, pointToPass);
            return result > 0;
        }

        public bool UpdateCourse(int courseID, string courseName, int courseCredits, int courseCatID, int classSessions, int maxAllowedAbsences, float pointToPass)
        {
            int result = courseModel.UpdateCourse(courseID, courseName, courseCredits, courseCatID, classSessions, maxAllowedAbsences, pointToPass);
            return result > 0;
        }

        public bool DeleteCourse(int courseID)
        {
            int result = courseModel.DeleteCourse(courseID);
            return result > 0;
        }
        public DataTable GetDeletedCourses()
        {
            return courseModel.GetDeletedCourses();
        }

        public bool RestoreCourse(int courseID)
        {
            int result = courseModel.RestoreCourse(courseID);
            return result > 0;
        }

        public bool PermanentlyDeleteCourse(int courseID)
        {
            int result = courseModel.PermanentlyDeleteCourse(courseID);
            return result > 0;
        }
    }
}
