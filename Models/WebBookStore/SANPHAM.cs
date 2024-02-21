namespace WebBookStore.Models.WebBookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            DANHGIAs = new HashSet<DANHGIA>();
        }

        public int ID { get; set; }

        public bool? TinhTrang { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public double? KhuyenMai { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        public long GiaSanPham { get; set; }

        public DateTime? NgaySanXuat { get; set; }

        public int SoLuong { get; set; }

        public bool? Moi { get; set; }

        public bool? DacBiet { get; set; }

        public int? LuotXem { get; set; }

        public int? MaTacGia { get; set; }

        public int? MaDMSach { get; set; }

        public int? MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }

        public virtual DANHMUCSACH DANHMUCSACH { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
