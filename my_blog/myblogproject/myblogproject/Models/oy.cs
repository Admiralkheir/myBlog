namespace myblogproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oy")]
    public partial class oy
    {
        public int oyID { get; set; }

        [StringLength(10)]
        public string oyTip { get; set; }

        public int? YorumID { get; set; }

        public virtual olumluOy olumluOy { get; set; }

        public virtual olumsuzOy olumsuzOy { get; set; }

        public virtual Yorum Yorum { get; set; }
    }
}
