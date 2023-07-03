using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gosteritiyatro.Models
{
    [Table("Kategoriler")]
    public partial class Kategoriler
    {
        [Key]
        [Column("kategori_id")]
        public int KategoriId { get; set; }
        [Column("ad")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ad { get; set; }
    }
}
