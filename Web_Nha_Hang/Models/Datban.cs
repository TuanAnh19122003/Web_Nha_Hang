namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datban")]
    public partial class Datban
    {
        [Key]
        [Required(ErrorMessage = "Đặt bàn không được để trống")]
        [Display(Name = "Đặt bàn")]
        public int madb { get; set; }

        [Required(ErrorMessage = "Bàn không được để trống")]
        [Display(Name = "Bàn")]
        public int? maban { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ tên")]
        public string hoten { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [Required(ErrorMessage = "Số lượng khách không được để trống")]
        [Display(Name = "Số lượng khách")]
        public int? soluongkh { get; set; }

        [Required(ErrorMessage = "Ngày đặt không được để trống")]
        [Display(Name = "Ngày đặt")]
        public DateTime? ngaydat { get; set; }

        [Required(ErrorMessage = "Ghi chú không được để trống")]
        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }

        public virtual Ban Ban { get; set; }
    }
}
