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
        [Key]
        [StringLength(50)]
        [Display(Name ="Mã sản phẩm")]
        public string ma { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string tensanpham { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? dongia { get; set; }

        [StringLength(50)]
        [Display(Name = "Hãng sản xuất")]
        public string hangsanxuat { get; set; }

        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        [StringLength(50)]
        [Display(Name = "Dòng máy")]
        public string producttype { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string imglink { get; set; }

        [Display(Name = "Mô tả")]
        public string mota { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
