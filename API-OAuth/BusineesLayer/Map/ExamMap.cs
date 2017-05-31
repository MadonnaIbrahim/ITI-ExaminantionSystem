using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Map
{
    public partial class ExamMap
    {
        public int Exam_Id { get; set; }
        public string Exam_Name { get; set; }
        public System.DateTime? Creation_Date { get; set; }
        public int? Number_Of_Questions { get; set; }
        public int? Ins_Id { get; set; }
        public bool? Exam_Corrected { get; set; }
        public int? Exam_Duration { get; set; }
        public int? PlatformIntake_Id { get; set; }
        
        //public virtual PlatfromIntake PlatfromIntake { get; set; }
        //public virtual ICollection<DepartmentsExam> DepartmentsExams { get; set; }
        //public virtual ICollection<NewDateExamForPermittedStudent> NewDateExamForPermittedStudents { get; set; }
        //public virtual ICollection<QuestionsInExam> QuestionsInExams { get; set; }
        //public virtual ICollection<StudentAnswerQuestionInExam> StudentAnswerQuestionInExams { get; set; }
        //public virtual ICollection<StudentPermissionInExam> StudentPermissionInExams { get; set; }
    }
}
