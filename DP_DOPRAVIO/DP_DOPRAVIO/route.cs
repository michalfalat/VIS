//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DP_DAIS
{
    using System;
    using System.Collections.Generic;
    
    public partial class route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public route()
        {
            this.timetable = new HashSet<timetable>();
        }
    
        public int id_route { get; set; }
        public string start { get; set; }
        public string finish { get; set; }
        public int stops_count { get; set; }
        public double distance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timetable> timetable { get; set; }
    }
}
