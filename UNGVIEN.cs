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
    
    public partial class UNGVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNGVIEN()
        {
            this.Applications = new HashSet<Applications>();
            this.LuuTin = new HashSet<LuuTin>();
            this.LuuCV = new HashSet<LuuCV>();
        }
    
        public string Id { get; set; }
        public string UserType { get; set; }
        public string Fname { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Address_C { get; set; }
        public string Gender { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }
        public virtual CVs CVs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuTin> LuuTin { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuCV> LuuCV { get; set; }
    }
}