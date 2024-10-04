using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.DTOs;
using Data.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace API.EntityModel
{
    public class DBSVContext:DbContext

    {
        public DBSVContext(DbContextOptions<DBSVContext> dbContextOptions)
        : base(dbContextOptions)
        {
        }
        //public override void OnConfiguring(DbContextOp)
        public DbSet<SINHVIEN> SINHVIENS {  get; set; }
        public DbSet<LOP> LOPS { get; set; }
        public DbSet<MONHOC> MONHOCS { get; set; }  
        public DbSet<KETQUA> KETQUAS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KETQUA>()
                .HasKey(e => new { e.MASV, e.MAMH}); // Định nghĩa khóa chính composite
            modelBuilder.Entity<LOP>()
               .HasKey(e => new { e.MALOP});
            modelBuilder.Entity<SINHVIEN>()
             .HasKey(e => new { e.MASV });
            modelBuilder.Entity<MONHOC>()
             .HasKey(e => new { e.MAMH });
            modelBuilder.Entity<SINHVIEN>()
            .ToTable("SINHVIEN");
            modelBuilder.Entity<LOP>()
           .ToTable("LOP");
            modelBuilder.Entity<MONHOC>()
           .ToTable("MONHOC");
            modelBuilder.Entity<KETQUA>()
           .ToTable("KETQUA");
      //      modelBuilder.Entity<SINHVIEN>()
      //.Property(s=>s.LOPMALOP)
      //.HasColumnName("LOPMALOP");
            // Có thể thêm cấu hình khác ở đây
        }
    }
}
