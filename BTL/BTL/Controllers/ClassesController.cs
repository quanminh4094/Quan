using System;
using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    public class ClassesController
    {
        private readonly ClassesModel model = new ClassesModel();

        public DataTable GetAllClasses()
        {
            return model.GetClasses();
        }

        public bool AddNewClass(string className, int courseId, int semesterId, int maxStudents)
        {
            return model.AddClass(className, courseId, semesterId, maxStudents) > 0;
        }

        public bool UpdateClass(int classId, string className, int courseId, int semesterId, int maxStudents)
        {
            return model.UpdateClass(classId, className, courseId, semesterId, maxStudents) > 0;
        }

        public bool DeleteClass(int classId)
        {
            return model.DeleteClass(classId) > 0;
        }

        public DataTable GetAllCourses()
        {
            return model.GetCourses();
        }

        public DataTable GetAllSemesters()
        {
            return model.GetSemesters();
        }

        public bool RestoreClass(int classId)
        {
            return model.RestoreClass(classId) > 0;
        }

        public bool PermanentDeleteClass(int classId)
        {
            return model.PermanentDeleteClass(classId) > 0;
        }

        public DataTable GetAllDeletedClasses()
        {
            return model.GetDeletedClasses();
        }

        
    }
}
