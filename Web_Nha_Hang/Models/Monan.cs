namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Monan")]
    public partial class Monan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monan()
        {
            Chitiethds = new HashSet<Chitiethd>();
        }

        [Key]
        public int mamon { get; set; }

        [Required(ErrorMessage = "Tên món không được để trống")]
        [Display(Name = "Tên món")]
        public string tenmon { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Danh mục không được để trống")]
        [Display(Name = "Danh mục")]
        public string madm { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh")]
        public string anh { get; set; }

        [Required(ErrorMessage = "Giá tiền không được để trống")]
        [Display(Name = "Giá tiền")]
        public decimal? giatien { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [Display(Name = "Mô tả")]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiethd> Chitiethds { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
