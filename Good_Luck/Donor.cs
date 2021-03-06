//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Good_Luck
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donor()
        {
            this.Contacts = new HashSet<Contact>();
            this.Donations = new HashSet<Donation>();
        }
    
        public decimal DonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> AdressId { get; set; }
        public string Phone { get; set; }
        public Nullable<short> Level { get; set; }
        public Nullable<decimal> GroupId { get; set; }
        public Nullable<decimal> LastDonation { get; set; }
        public string Comments { get; set; }
        public string CollectTime { get; set; }
        public string IsActive { get; set; }
        public string StatusDonation { get; set; }
    
        public virtual Adress Adress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual Group Group { get; set; }
    }
}
