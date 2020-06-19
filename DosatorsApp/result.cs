namespace DosatorsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("result")]
    public partial class result
    {
        [Key]
        public int id { get; set; }

        public int codeDos { get; set; }

        public int objem { get; set; }

        public float procent { get; set; }

        public float vosproizv { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateTest { get; set; }

        [Required]
        [StringLength(50)]
        public string operators { get; set; }

        public virtual dosators dosators { get; set; }
    }
}
