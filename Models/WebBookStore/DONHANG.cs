namespace WebBookStore.Models.WebBookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public DateTime? NgayNhanHang { get; set; }

        [StringLength(50)]
        public string EmailNguoiNhan { get; set; }

        public int? TinhTrang { get; set; }

        [Required]
        [StringLength(10)]
        public string MaVanDon { get; set; }

        public int? MaKhachHang { get; set; }

        public double? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
