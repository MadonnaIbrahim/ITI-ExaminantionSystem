using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Managers
{
    public class QuestionsInExamManager: DataFactory<DataBaseCTX,QuestionsInExam>
    {
        QuestionsInExamManager QSEMgr;
        public QuestionsInExam AddQuestionToExam(QuestionsInExam questExam)
        {
            QSEMgr = new QuestionsInExamManager();

            var result=QSEMgr.Add(questExam);
            return result;
        }
        public bool AddManyQuestionToExam(int Exam_id,List<int> Ques_ids,List<int> Ques_Degrees)
        {
            QSEMgr = new QuestionsInExamManager();
            List<QuestionsInExam> QuestExamList = new List<QuestionsInExam>();
            for (int i = 0; i < Ques_ids.Count(); i++)
            {
                QuestionsInExam QuesExam = new QuestionsInExam()
                {
                    Exam_Id = Exam_id,
                    Ques_Id = Ques_ids[i],
                    Degree = Ques_Degrees[i]
                };
                QuestExamList.Add(QuesExam);
            }
            var result = QSEMgr.AddRange(QuestExamList);
            return result;
        }

        public bool DeleteExamQuestion(int Exam_id)
        {
            var result=QSEMgr.Delete(Exam_id);
            return result;
        }

        public bool DeleteSomeQuestions(int Exam_id,List<int> Ques_Ids)
        {
            bool flag;
            using (var context = new DataBaseCTX())
            {
                int allQuestNo = context.QuestionsInExams.Where(a => a.Exam_Id == Exam_id).Count();
                foreach (var item in Ques_Ids)
                {
                    var x = (from q in context.QuestionsInExams
                             where q.Exam_Id == Exam_id && q.Ques_Id == item
                             select q).FirstOrDefault();
                    context.QuestionsInExams.Remove(x);
                    context.SaveChanges();
                }
                int QuentAfterDeleted = context.QuestionsInExams.Where(a => a.Exam_Id == Exam_id).Count();
                if((allQuestNo- QuentAfterDeleted)==Ques_Ids.Count())
                {
                    flag= true;
                }

                else
                {
                    flag = false;
                }
            }

            return flag;

        }

        

    }
}
