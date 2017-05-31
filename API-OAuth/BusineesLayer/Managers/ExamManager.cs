using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;
using BusineesLayer.Map;
using BusineesLayer.Models;
namespace BusineesLayer.Managers
{
    public class ExamManager : DataFactory<DataBaseCTX, Exam>
    {

        ExamManager examManager;
        EmployeeManager empMgr;
        enum Types { mcq, tf, editable }
        enum levels { easy, hard, veryhard }
        public bool AddExam(Exam exam)//
        {

            examManager = new ExamManager();
            empMgr = new EmployeeManager();
            BranchManager Bmgr = new BranchManager();
            var Branch_Id = empMgr.GetEmpBranchId(exam.Ins_Id.Value);
            var BranchName = Bmgr.GetBranchById(Branch_Id).BranchName;
            exam.Exam_Name = BranchName + "date";
            var Result = examManager.Add(exam);
            if (Result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetExams()//
        {
             examManager = new ExamManager();
            var exams_list = examManager.GetAll().ToList();
            var mappedlist = Mapper.Map<List<ExamMap>>(exams_list);
            if (mappedlist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExam(int Exam_Id)//
        {
            examManager = new ExamManager();
            var result=examManager.Delete(Exam_Id);
            return result;
        }

        public List<QuestionMap> getQuestionsRandomly(AutoExam[] ExamArr)
        {
            List<Question> ExamQuestion = new List<Question>();
            using (var context = new DataBaseCTX())
            {
               
                foreach (var item in ExamArr)
                {
                    int Type = (int)(Types)Enum.Parse(typeof(Types),item.Ques_Type);
                    int Level = (int)(levels)Enum.Parse(typeof(levels), item.Ques_Level);
                    Random rand = new Random();
                    var Z = rand.Next();
                    var Y = context.Questions.Where(x=>(x.Ques_Type==Type) && (x.Ques_Level==Level)&& (x.Topic_Id==item.Topic_Id)).OrderBy(a =>Z).Take(item.Ques_No).ToList();
                    ExamQuestion.AddRange(Y);
                }
            }
            var mappedlist = Mapper.Map<List<QuestionMap>>(ExamQuestion);
            return mappedlist;
        }
    }
}