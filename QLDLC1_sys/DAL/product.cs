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
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.BillExportDetails = new HashSet<BillExportDetails>();
            this.BillImportDetails = new HashSet<BillImportDetails>();
        }
    
        public int ProductId { get; set; }
        public Nullable<int> NhaSXId { get; set; }
        public Nullable<int> ProductGroupName { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        public string ProductInfo { get; set; }
        public string ProductImageLink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillExportDetails> BillExportDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillImportDetails> BillImportDetails { get; set; }
        public virtual productgroup productgroup { get; set; }
        public virtual NhaSX NhaSX { get; set; }
    }
}
