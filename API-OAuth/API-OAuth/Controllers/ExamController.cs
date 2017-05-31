using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusineesLayer.Managers;
using BusineesLayer.Map;
using BusineesLayer.Models;

namespace API_OAuth.Controllers
{
    public class ExamController : ApiController
    {
        ExamManager ExamMgr;
        QuestionsInExamManager QEMgr;

      [System.Web.Http.HttpGet]
        public bool GetExams() //
        {
            ExamMgr = new ExamManager();
            return ExamMgr.GetExams();
        }

        [HttpPost]
        public bool PostExam(Exam exam)//
        {
            ExamMgr = new ExamManager();
            var result=ExamMgr.AddExam(exam);
            return result;
        }
        [HttpDelete]
        public bool DeleteExam(int Exam_Id)//
        {
            ExamMgr = new ExamManager();
            return ExamMgr.DeleteExam(Exam_Id);
        }


        ///////////////////////////////////////////////////////Question In Exam Controller/////////////////////////////////////////////////
        [HttpPost]
        public QuestionsInExam PostQuestionToExam(QuestionsInExam QuestExam)
        {
             QEMgr = new QuestionsInExamManager();
            var result = QEMgr.Add(QuestExam);
            return result;
        }

        [HttpDelete]
        public bool DeleteSomeQuestions(int Exam_id, List<int> Ques_Ids)
        {
            QEMgr = new QuestionsInExamManager();
            var result=QEMgr.DeleteSomeQuestions(Exam_id, Ques_Ids);
            return result;
        }

        [HttpPost]
        public bool POSTManyQuestionToExam(int Exam_id, List<int> Ques_ids, List<int> Ques_Degrees)
        {
             QEMgr = new QuestionsInExamManager();
           var result=QEMgr.AddManyQuestionToExam(Exam_id, Ques_ids, Ques_Degrees);
            return result;
        }
        /////////////////////////////////////////////////////DepartmentExam///////////////////////////////////////////////////////////
        [HttpGet]
        public DepartmentsExamMap GetDepartmentExam(int Exam_id, int Branch_id, int Subtrack_id)
        {
            DepartmentExamsManager DEMgr = new DepartmentExamsManager();
            var result=DEMgr.getDepartmentExam(Exam_id, Branch_id, Subtrack_id);
            return result;
        }

        [HttpDelete]
        public bool DeleteExamFromDepartmentExam(int Exam_Id)
        {
            DepartmentExamsManager DEMgr = new DepartmentExamsManager();
            var result = DEMgr.DeleteExamFromDepartmentExam(Exam_Id);
            return result;
        }
        [HttpDelete]
       public bool removeDepartmentExam(int Exam_id, int SubTrack_Id, int Branch_Id)
        {
            DepartmentExamsManager DEMgr = new DepartmentExamsManager();
            var result=DEMgr.removeDepartmentExam(Exam_id, SubTrack_Id, Branch_Id);
            return result;
        }
        public bool ChangeDepartmentExamDate(DepartmentsExam DeptExam, DateTime NewDate)
        {
            DepartmentExamsManager DEMgr = new DepartmentExamsManager();
            var result = DEMgr.ChangeDepartmentExamDate(DeptExam, NewDate);
            return result;
        }
        [HttpPost]
        public bool AddDepartmentExam(int Exam_id, List<int> PlatformIntake_Ids, List<DateTime> Exam_date)
        {
            DepartmentExamsManager DEMgr = new DepartmentExamsManager();
            var result = DEMgr.AddDepartmentsExam(Exam_id, PlatformIntake_Ids, Exam_date);
            return result;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //public ExamMap GetExamsByDate(int plaTFormIntakeId, DateTime date)
        //{
        //    DepartmentExamsManager DEMgr = new DepartmentExamsManager();
        //    var result=DEMgr.GetExamByDate(plaTFormIntakeId, date);
        //    return result;
        //}

        //public List<ExamMap> GetDepartmentExamByDate(DateTime Date)
        //{
        //    DepartmentExamsManager DEMgr = new DepartmentExamsManager();
        //    var result = DEMgr.GetDepartmentExamByDate(Date);
        //    return result;
        //}

        //////////////////////////////////// autoGenerate Exam////////////////////////////////////////////////////////////////////////
        
            [Route("api/Exam/PostQuestionsRandomly")]
        public List<QuestionMap> PostQuestionsRandomly(AutoExam[] ExamArr)
        {
            ExamManager ExMgr=new ExamManager();
           var result=ExMgr.getQuestionsRandomly(ExamArr);
            return result;
        }

    }
}
