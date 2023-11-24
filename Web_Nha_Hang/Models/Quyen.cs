namespace Web_Nha_Hang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quyen()
        {
            Nguoidungs = new HashSet<Nguoidung>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Quyền không được để trống")]
        [Display(Name = "Quyền")]
        public string maquyen { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên quyền không được để trống")]
        [Display(Name = "Tên quyền")]
        public string tenquyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}
