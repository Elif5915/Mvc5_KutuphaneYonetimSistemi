//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc5_KutuphaneYonetimSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hareket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hareket()
        {
            this.Cezalar = new HashSet<Cezalar>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Kıtap { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<int> Personel { get; set; }
        public Nullable<System.DateTime> AlisTarihi { get; set; }
        public Nullable<System.DateTime> IadeTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cezalar> Cezalar { get; set; }
        public virtual Kitap Kitap { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}
