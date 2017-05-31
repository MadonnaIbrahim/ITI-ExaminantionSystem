using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;

namespace BusineesLayer.Managers
{
    public class StudentMananger : DataFactory<DataBaseCTX , StudentBasicData>
    {
        public List<StudentBasicData> GetStudents()
        {
            var xx = new StudentMananger().GetAll().ToList();
            return xx;
        }

        public Student GetOnly()
        {
            var mm = new StudentMananger().GetById(5747);
            var zz = Mapper.Map<Student>(mm);
            return zz;
        }

        
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string englishname { get; set; }
    }
}
