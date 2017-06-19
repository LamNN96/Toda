namespace TodaWebDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWeb")]
    public partial class UserWeb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserWeb()
        {
            Requests = new HashSet<Request>();
        }

        public int? ID { get; set; }

        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? RoleID { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
