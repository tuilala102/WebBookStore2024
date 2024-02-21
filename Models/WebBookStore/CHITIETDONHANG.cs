namespace WebBookStore.Models.WebBookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        public int ID { get; set; }

        public double? KhuyenMai { get; set; }

        public int? MaDonHang { get; set; }

        public int? MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public long? DonGia { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
