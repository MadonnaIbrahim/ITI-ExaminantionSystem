using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Map
{
    public partial class DepartmentsExamMap
    {
        public int Exam_Id { get; set; }
        public int PlatformIntakeID { get; set; }
        public System.DateTime? Exam_Date { get; set; }

        //public virtual PlatfromIntake PlatfromIntake { get; set; }
    }
}
