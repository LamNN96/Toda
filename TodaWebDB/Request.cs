namespace TodaWebDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public string Value { get; set; }

        public int? PhongBan { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public bool? Status { get; set; }

        public DateTime? Time { get; set; }

        public virtual UserWeb UserWeb { get; set; }
    }
}
