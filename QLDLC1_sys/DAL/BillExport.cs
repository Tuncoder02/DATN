//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillExport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillExport()
        {
            this.BillExportDetails = new HashSet<BillExportDetails>();
        }
    
        public int BillExportId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public System.DateTime BillExportDate { get; set; }
        public Nullable<double> BillTotalMoney { get; set; }
        public Nullable<int> BillPayPercent { get; set; }
        public Nullable<int> BillDiscount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillExportDetails> BillExportDetails { get; set; }
        public virtual customer customer { get; set; }
    }
}
