namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubCategory")]
    public partial class SubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name ="Mã danh mục con")]
        public string mahienthi { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên danh mục con")]
        public string tendanhmuccon { get; set; }

        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        //[Display(Name = "Mã danh mục con")]
        public Guid? danhmucma { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
