using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_Nha_Hang.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBConnectNhaHang")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<Chitiethd> Chitiethds { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Datban> Datbans { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Monan> Monans { get; set; }
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethd>()
                .Property(e => e.dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.tongtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Monan>()
                .Property(e => e.giatien)
                .HasPrecision(18, 0);
        }
    }
}
