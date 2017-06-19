namespace TodaWebDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TodaWebDbContext : DbContext
    {
        public TodaWebDbContext()
            : base("name=TodaWebDbContext")
        {
        }

        public virtual DbSet<PhongBanKhachHang> PhongBanKhachHangs { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<UserWeb> UserWebs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserWeb>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<UserWeb>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserWeb>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);
            modelBuilder.Entity<Request>().GetType();
            modelBuilder.Entity<UserWeb>()
                .HasMany(e => e.Requests)
                .WithOptional(e => e.UserWeb)
                .HasForeignKey(e => e.UserID);
        }
    }
}
