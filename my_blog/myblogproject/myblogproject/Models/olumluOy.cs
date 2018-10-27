namespace myblogproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("olumluOy")]
    public partial class olumluOy
    {
        [Key]
        public int oyID { get; set; }

        public virtual oy oy { get; set; }
    }
}
