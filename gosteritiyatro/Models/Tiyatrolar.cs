using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gosteritiyatro.Models
{
    [Table("Tiyatrolar")]
    public partial class Tiyatrolar
    {
        public Tiyatrolar()
        {
            Sahnes = new HashSet<Sahne>();
        }

        [Key]
        [Column("tiyatro_id")]
        public int TiyatroId { get; set; }
        [Column("ad")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Ad { get; set; }
        [Column("adres")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Adres { get; set; }
        [Column("sehir")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Sehir { get; set; }
        [Column("ulke")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ulke { get; set; }

        [InverseProperty("Tiyatro")]
        public virtual ICollection<Sahne> Sahnes { get; set; }
    }
}
