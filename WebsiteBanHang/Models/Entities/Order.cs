namespace WebsiteBanHang.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public long ma { get; set; }

        public DateTime? ngaytao { get; set; }

        [StringLength(50)]
        public string makhachhang { get; set; }

        [StringLength(50)]
        public string shipName { get; set; }

        [StringLength(50)]
        public string shipMobile { get; set; }

        public string shipAddress { get; set; }

        [StringLength(50)]
        public string shipEmail { get; set; }

        public int? status { get; set; }
    }
}
