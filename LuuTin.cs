//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Windows_04
{
    using System;
    using System.Collections.Generic;
    
    public partial class LuuTin
    {
        public string IdCompany { get; set; }
        public string IdJobPostings { get; set; }
        public string IdCandidate { get; set; }
        public string Follow { get; set; }
    
        public virtual JobPostings JobPostings { get; set; }
        public virtual UNGVIEN UNGVIEN { get; set; }
    }
}
