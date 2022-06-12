namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_DichVu
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string TenDichVu { get; set; }

        public string MoTa { get; set; }

        [StringLength(100)]
        public string Gia { get; set; }

        public int? ID_LoaiDichVu { get; set; }

        public int? ID_NhaCungCapAI { get; set; }

        public int? ID_User { get; set; }
    }
}
