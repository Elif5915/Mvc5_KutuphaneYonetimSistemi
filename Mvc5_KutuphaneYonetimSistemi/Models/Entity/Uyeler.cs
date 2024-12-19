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
	using System.ComponentModel.DataAnnotations;

	public partial class Uyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uyeler()
        {
            this.Cezalar = new HashSet<Cezalar>();
            this.Hareket = new HashSet<Hareket>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad Alan� Bo� B�rak�lamaz!")]
        [StringLength(20,ErrorMessage ="En Fazla 20 Karakter Girebilirsiniz!")]
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Mail { get; set; }
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "�ifre Alan� Bo� B�rak�lamaz!")]
        [StringLength(1, ErrorMessage = "En Fazla 1 Karakter Girebilirsiniz!")]
        public string Sifre { get; set; }
        public string Fotograf { get; set; }
        public string Telefon { get; set; }
        public string Okul { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cezalar> Cezalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hareket> Hareket { get; set; }
    }
}
