using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gosteritiyatro.Models
{
    [Table("Yonetmenler")]
    public partial class Yonetmenler
    {
        [Key]
        [Column("yonetmen_id")]
        public int YonetmenId { get; set; }
        [Column("ad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ad { get; set; }
        [Column("soyad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Soyad { get; set; }
        [Column("dogum_tarihi", TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }
        [Column("ulke")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ulke { get; set; }
    }
}
