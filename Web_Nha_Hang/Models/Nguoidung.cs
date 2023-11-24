namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nguoidung")]
    public partial class Nguoidung
    {
        [Key]
        public int mand { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [Display(Name = "Tài khoản")]
        public string taikhoan { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu")]
        public string matkhau { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh")]
        public string anh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Quyền không được để trống")]
        [Display(Name = "Quyền")]
        public string maquyen { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email không được để trống")]
        [Display(Name = "Email")]
        public string email { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
