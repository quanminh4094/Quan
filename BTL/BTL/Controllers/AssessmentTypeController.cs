using System.Data;
using BTL.Models;

namespace BTL.Controllers
{
    internal class AssessmentTypeController
    {
        private AssessmentTypeModel assessmentTypeModel = new AssessmentTypeModel();

        public DataTable GetAssessmentTypes()
        {
            return assessmentTypeModel.GetAssessmentTypes();
        }

        public bool AddAssessmentType(int courseID, string assTypeName, float weightPercentage, int examsNo)
        {
            int result = assessmentTypeModel.AddAssessmentType(courseID, assTypeName, weightPercentage, examsNo);
            return result > 0;
        }

        public bool UpdateAssessmentType(int assTypeID, int courseID, string assTypeName, float weightPercentage, int examsNo)
        {
            int result = assessmentTypeModel.UpdateAssessmentType(assTypeID, courseID, assTypeName, weightPercentage, examsNo);
            return result > 0;
        }

        public bool SoftDeleteAssessmentType(int assTypeID)
        {
            int result = assessmentTypeModel.SoftDeleteAssessmentType(assTypeID);
            return result > 0;
        }
        public DataTable GetDeletedAssessmentTypes()
        {
            return assessmentTypeModel.GetDeletedAssessmentTypes();
        }

        public bool RestoreAssessmentType(int assTypeID)
        {
            int result = assessmentTypeModel.RestoreAssessmentType(assTypeID);
            return result > 0;
        }

        public bool PermanentlyDeleteAssessmentType(int assTypeID)
        {
            int result = assessmentTypeModel.PermanentlyDeleteAssessmentType(assTypeID);
            return result > 0;
        }

    }
}
