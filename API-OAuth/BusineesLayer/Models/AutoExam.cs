using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusineesLayer.Models
{
    public class AutoExam
    {
        public int Topic_Id { get; set; }
        public String Ques_Type { get; set; }

        public String Ques_Level { get; set; }
        public int Ques_No { get; set; }
    }
}