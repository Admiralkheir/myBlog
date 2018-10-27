namespace myblogproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yorum()
        {
            oys = new HashSet<oy>();
        }

        public int YorumID { get; set; }

        public int? KullaniciID { get; set; }

        public int? MakaleID { get; set; }

        [StringLength(500)]
        public string Yorum_İcerik { get; set; }

        public DateTime? Yorum_Tarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Makale Makale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oy> oys { get; set; }
    }
}
