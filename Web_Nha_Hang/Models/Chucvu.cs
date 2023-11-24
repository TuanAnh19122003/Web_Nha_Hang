namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chucvu")]
    public partial class Chucvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chucvu()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Chức vụ không được để trống")]
        [Display(Name = "Chức vụ")]
        public string macv { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên chức vụ không được để trống")]
        [Display(Name = "Tên chức vụ")]
        public string tencv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
