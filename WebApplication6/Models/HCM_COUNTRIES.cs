//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HCM_COUNTRIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HCM_COUNTRIES()
        {
            this.hc_client_user = new HashSet<hc_client_user>();
        }
    
        public long RID { get; set; }
        public string CountryTitle { get; set; }
        public long MCreatedUser { get; set; }
        public Nullable<System.DateTime> MCreatedDate { get; set; }
        public long MModifiedUser { get; set; }
        public Nullable<System.DateTime> MModifiedDate { get; set; }
        public int ProbationPeriod { get; set; }
        public string CountryCode { get; set; }
        public string ISDCode { get; set; }
        public short LanguageType { get; set; }
        public long EngKeyID { get; set; }
        public long SerialNo { get; set; }
        public long LayoutID { get; set; }
        public long CurrencyID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hc_client_user> hc_client_user { get; set; }
    }
}
