namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        [Key]
        [StringLength(50)]
        public string ma { get; set; }

        [StringLength(50)]
        public string tensanpham { get; set; }

        public decimal? dongia { get; set; }

        [StringLength(50)]
        public string hangsanxuat { get; set; }

        public int? soluong { get; set; }

        [StringLength(50)]
        public string producttype { get; set; }

        [StringLength(50)]
        public string imglink { get; set; }

        public string mota { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
