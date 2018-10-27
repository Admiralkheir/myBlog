namespace myblogproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makale")]
    public partial class Makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makale()
        {
            Yorum = new HashSet<Yorum>();
            AnahtarKelime = new HashSet<AnahtarKelime>();
        }

        public int MakaleID { get; set; }

        public int? KategoriID { get; set; }

        public int? KullaniciID { get; set; }
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        public string Makale_İcerik { get; set; }
        [Display(Name = "Tarih")]
        public DateTime? Makale_Tarih { get; set; }
        [StringLength(500)]
        [Display(Name = "Makale Resmi")]
        public string Makale_Resim { get; set; }
        [Display(Name = "Beğeni")]
        public int? Begeni { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnahtarKelime> AnahtarKelime { get; set; }
    }
}
