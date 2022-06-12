namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_User
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string TenDayDu { get; set; }

        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool? isAdmin { get; set; }

        [StringLength(100)]
        public string Type { get; set; }
    }
}
