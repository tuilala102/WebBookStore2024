namespace WebBookStore.Models.WebBookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIA")]
    public partial class DANHGIA
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string BinhLuan { get; set; }

        public int? SoSao { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaKhachHang { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
