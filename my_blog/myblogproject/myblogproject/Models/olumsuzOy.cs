namespace myblogproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("olumsuzOy")]
    public partial class olumsuzOy
    {
        [Key]
        public int oyID { get; set; }

        public virtual oy oy { get; set; }
    }
}
