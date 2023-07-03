using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gosteritiyatro.Models
{
    [Table("Sahne")]
    public partial class Sahne
    {
        [Key]
        [Column("sahne_id")]
        public int SahneId { get; set; }
        [Column("tiyatro_id")]
        public int? TiyatroId { get; set; }
        [Column("ad")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Ad { get; set; }
        [Column("kapasite")]
        public int? Kapasite { get; set; }

        [ForeignKey("TiyatroId")]
        [InverseProperty("Sahnes")]
        public virtual Tiyatrolar? Tiyatro { get; set; }
    }
}
