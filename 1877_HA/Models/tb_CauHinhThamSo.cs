namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CauHinhThamSo
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TenTruong { get; set; }

        public int? ID_DichVu { get; set; }

        public string MoTa { get; set; }
    }
}
