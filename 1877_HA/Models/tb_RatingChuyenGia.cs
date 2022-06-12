namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_RatingChuyenGia
    {
        public int ID { get; set; }

        public float? Star { get; set; }

        [StringLength(200)]
        public string BinhLuan { get; set; }

        public int? ID_ChuyenGia { get; set; }
        public int? ID_KhachHang { get; set; }
    }
}
