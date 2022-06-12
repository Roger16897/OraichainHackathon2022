namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_LoaiDichVu
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TenLoaiDichVu { get; set; }

        [StringLength(200)]
        public string Gia { get; set; }

        public string MoTa { get; set; }
    }
}
