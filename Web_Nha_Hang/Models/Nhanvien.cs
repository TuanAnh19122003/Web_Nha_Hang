namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhanvien")]
    public partial class Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        [Key]
        public int manv { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chức vụ không được để trống")]
        [Display(Name = "Chức vụ")]
        public string macv { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên chức vụ không được để trống")]
        [Display(Name = "Tên chức vụ")]
        public string tennv { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh")]
        public string anh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        [Display(Name = "Giới tính")]
        public string gioitinh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        public string ngsinh { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
