namespace DosatorsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("norma")]
    public partial class norma
    {
        [Key]
        public int id { get; set; }

        public int volume { get; set; }

        public float precis { get; set; }

        public float reproducibility { get; set; }

        public int codeDos { get; set; }

        public virtual dosators dosators { get; set; }
    }
}
