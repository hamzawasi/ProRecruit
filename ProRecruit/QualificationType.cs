//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProRecruit
{
    using System;
    using System.Collections.Generic;
    
    public partial class QualificationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QualificationType()
        {
            this.CandidateQualifications = new HashSet<CandidateQualification>();
        }
    
        public int Id { get; set; }
        public string TypeName { get; set; }
        public Nullable<int> TypeOf { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CandidateQualification> CandidateQualifications { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}
