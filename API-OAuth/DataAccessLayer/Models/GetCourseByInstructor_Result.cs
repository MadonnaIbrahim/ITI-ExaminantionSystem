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
    
    public partial class GetCourseByInstructor_Result
    {
        public string BranchName { get; set; }
        public string subtrackName { get; set; }
        public string CourseName { get; set; }
        public int CourseInstanceID { get; set; }
        public int EvaluatedCourse { get; set; }
        public Nullable<int> SubTrackID { get; set; }
        public Nullable<int> BranchID { get; set; }
        public string CourseDescription { get; set; }
        public Nullable<int> eval { get; set; }
        public Nullable<int> Studentcont { get; set; }
    }
}