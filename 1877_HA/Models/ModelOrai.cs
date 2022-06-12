namespace _1877_HA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelOrai : DbContext
    {
        public ModelOrai()
            : base("name=ModelOrai")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_Action> tb_Action { get; set; }
        public virtual DbSet<tb_CauHinhThamSo> tb_CauHinhThamSo { get; set; }
        public virtual DbSet<tb_ChuyenGia> tb_ChuyenGia { get; set; }
        public virtual DbSet<tb_CongViec> tb_CongViec { get; set; }
        public virtual DbSet<tb_Controller> tb_Controller { get; set; }
        public virtual DbSet<tb_DichVu> tb_DichVu { get; set; }
        public virtual DbSet<tb_LoaiDichVu> tb_LoaiDichVu { get; set; }
        public virtual DbSet<tb_NhaCungCapAI> tb_NhaCungCapAI { get; set; }
        public virtual DbSet<tb_PhanQuyen> tb_PhanQuyen { get; set; }
        public virtual DbSet<tb_RatingChuyenGia> tb_RatingChuyenGia { get; set; }
        public virtual DbSet<tb_RatingNhaCungCap> tb_RatingNhaCungCap { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }
        public virtual DbSet<tb_KetQuaAI> tb_KetQuaAI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
