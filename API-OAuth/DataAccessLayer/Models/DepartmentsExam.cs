//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentsExam
    {
        public int Exam_Id { get; set; }
        public int PlatformIntakeID { get; set; }
        public Nullable<System.DateTime> Exam_Date { get; set; }
    
        public virtual PlatfromIntake PlatfromIntake { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
