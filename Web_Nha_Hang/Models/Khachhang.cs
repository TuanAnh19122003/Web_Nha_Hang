namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khachhang")]
    public partial class Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        [Display(Name = "Tên khách hàng")]
        public string tenkh { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh")]
        public string anh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email không được để trống")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
