namespace TodaWebDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBanKhachHang")]
    public partial class PhongBanKhachHang
    {
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Value { get; set; }
    }
}
