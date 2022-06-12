namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ChuyenGia
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string TenChuyenGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string TrinhDo { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        [StringLength(200)]
        public string Image { get; set; }
    }
}
