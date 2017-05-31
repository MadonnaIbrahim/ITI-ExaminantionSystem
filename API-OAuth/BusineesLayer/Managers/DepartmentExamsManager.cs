using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using BusineesLayer.Map;
using AutoMapper;

namespace BusineesLayer.Managers
{
    
    public class DepartmentExamsManager: DataFactory<DataBaseCTX,DepartmentsExam>
    {
        DataBaseCTX Context;
        DepartmentExamsManager DEMagr;
        public DepartmentsExamMap getDepartmentExam(int Exam_id,int Branch_id,int Subtrack_id)
        {
            PlatformIntakeManager PImgr = new PlatformIntakeManager();
            DEMagr = new DepartmentExamsManager();
            int platformIntake_Id = PImgr.GetPlatFormIntakeId(Branch_id, Subtrack_id);
            var ListByExam = DEMagr.FindListBy(x => x.Exam_Id.Equals(Exam_id)).ToList();
            DepartmentsExam DeptExam = new DepartmentsExam();
            foreach (var subtrack in ListByExam)
            {
                DeptExam = ListByExam.Find(x => x.PlatformIntakeID.Equals(platformIntake_Id));
            }
            var MappedExam = Mapper.Map<DepartmentsExamMap>(DeptExam);
            return MappedExam;
        }
        public bool AddDepartmentsExam(int Exam_id,List<int>PlatformIntake_Ids,List<DateTime> Exam_date)//
        {
            DEMagr = new DepartmentExamsManager();
            List<DepartmentsExam> AddedList = new List<DepartmentsExam>();
            for (int i=0;i<PlatformIntake_Ids.Count();i++)
            {
                DepartmentsExam DeptExam = new DepartmentsExam()
                {
                    Exam_Id = Exam_id,
                    PlatformIntakeID = PlatformIntake_Ids[i],
                    Exam_Date = Exam_date[0]

                };
                AddedList.Add(DeptExam);
            }
             var result = DEMagr.AddRange(AddedList);
            return result;
        }

        public bool DeleteExamFromDepartmentExam(int Exam_Id)
        {
            DEMagr = new DepartmentExamsManager();
            var result=DEMagr.Delete(Exam_Id);
            return result;
        }

        public bool removeDepartmentExam(int Exam_id,int SubTrack_Id,int Branch_Id)
        {
            DEMagr = new DepartmentExamsManager();
            var deptExam = DEMagr.getDepartmentExam(Exam_id, SubTrack_Id, Branch_Id);
            var result=DEMagr.Delete(deptExam.Exam_Id);
            return result;
        }

        public bool ChangeDepartmentExamDate( DepartmentsExam DeptExam,DateTime NewDate)
        {
            DEMagr = new DepartmentExamsManager();
            DeptExam.Exam_Date = NewDate;
            var result= DEMagr.Update(DeptExam);
            return result;
        }

        //public ExamMap GetExamByDate(int plaTFormIntakeId,DateTime ExamDate)
        //{
        //    Context = new DataBaseCTX();
        //    var ExamDept = (from e in Context.DepartmentsExams
        //                where e.PlatformIntakeID == plaTFormIntakeId && e.Exam_Date == ExamDate
        //                select e).FirstOrDefault();
        //    ExamManager EXMgr = new ExamManager();
        //     var exam= EXMgr.GetById(ExamDept.Exam_Id);

        //    var MappedExam = Mapper.Map<ExamMap>(exam);
        //    return MappedExam;
        //}

        //public List<ExamMap> GetDepartmentExamByDate( DateTime ExamDate)
        //{
        //    ExamManager EXMgr = new ExamManager();
        //    DEMagr = new DepartmentExamsManager();
        //    List<Exam> ExamsList = new List<Exam>();
        //    var DeptExamsList=DEMagr.FindListBy(x => x.Exam_Date.Value.Equals(ExamDate)).ToList();
        //    foreach (var item in DeptExamsList)
        //    {
        //        var Exam = EXMgr.GetById(item.Exam_Id);
        //        ExamsList.Add(Exam);
        //    }

        //    var MappedList = Mapper.Map<List<ExamMap>>(ExamsList);
        //    return MappedList;
        //}



    }

}
