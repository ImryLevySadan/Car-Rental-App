//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarIsYourHome
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars_Type()
        {
            this.Cars_List = new HashSet<Cars_List>();
        }
    
        public int Type_ID { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public decimal Daily_Cost { get; set; }
        public decimal Daily_Delay_Cost { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cars_List> Cars_List { get; set; }
    }
}
