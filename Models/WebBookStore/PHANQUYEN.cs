namespace WebBookStore.Models.WebBookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANQUYEN")]
    public partial class PHANQUYEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaNhomND { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaQuyen { get; set; }

        [StringLength(100)]
        public string TenPQ { get; set; }

        public virtual NHOMND NHOMND { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
