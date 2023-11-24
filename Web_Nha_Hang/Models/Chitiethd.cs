namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitiethd")]
    public partial class Chitiethd
    {
        [Key]
        public int macthd { get; set; }
        [Required(ErrorMessage = "Mã hóa đơn không được để trống")]
        [Display(Name = "Mã hóa đơn")]
        public int? mahd { get; set; }
        [Required(ErrorMessage = "Mã món không được để trống")]
        [Display(Name = "Mã món")]
        public int? mamon { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Display(Name = "Đơn giá")]
        public decimal? dongia { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Thành tiền không được để trống")]
        [Display(Name = "Thành tiền")]
        public string thanhtien { get; set; }

        public virtual Hoadon Hoadon { get; set; }

        public virtual Monan Monan { get; set; }
    }
}
