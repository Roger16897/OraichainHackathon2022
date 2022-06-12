namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NhaCungCapAI
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TenNhaCungCap { get; set; }

        public string MoTa { get; set; }

        public int? ID_LoaiDichVu { get; set; }
    }
}
