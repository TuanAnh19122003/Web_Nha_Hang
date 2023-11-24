namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadon")]
    public partial class Hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoadon()
        {
            Chitiethds = new HashSet<Chitiethd>();
        }

        [Key]
        [Required(ErrorMessage = "Hóa đơn không được để trống")]
        [Display(Name = "Hóa đơn")]
        public int mahd { get; set; }


        [Required(ErrorMessage = "Nhân viên không được để trống")]
        [Display(Name = "Nhân viên")]
        public int? manv { get; set; }

        [Required(ErrorMessage = "Khách hàng không được để trống")]
        [Display(Name = "Khách hàng")]
        public int? makh { get; set; }

        [Required(ErrorMessage = "Ngày thanh toán không được để trống")]
        [Display(Name = "Ngày thanh toán")]
        public DateTime? ngaythanhtoan { get; set; }

        [Required(ErrorMessage = "Tổng tiền không được để trống")]
        [Display(Name = "Tổng tiền")]
        public decimal? tongtien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiethd> Chitiethds { get; set; }

        public virtual Khachhang Khachhang { get; set; }

        public virtual Nhanvien Nhanvien { get; set; }
    }
}
