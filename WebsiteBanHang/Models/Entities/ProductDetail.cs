namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Mã sản phẩm")]
        public string masanpham { get; set; }

        [StringLength(10)]
        [Display(Name = "Ram")]
        public string ram { get; set; }

        [StringLength(20)]
        [Display(Name = "Đĩa cứng")]
        public string diacung { get; set; }

        [StringLength(20)]
        [Display(Name = "Card đồ họa")]
        public string vga { get; set; }

        [StringLength(20)]
        [Display(Name = "Màn hình")]
        public string manhinh { get; set; }

        [StringLength(20)]
        [Display(Name = "Vi xử lý")]
        public string vixuly { get; set; }

        public virtual Product Product { get; set; }
    }
}
