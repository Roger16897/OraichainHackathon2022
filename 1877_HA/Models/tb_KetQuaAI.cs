namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_KetQuaAI
    {
        public int ID { get; set; }

        public int? ID_DichVu { get; set; }

        public int? ID_User { get; set; }

        public string KetQuaNhaCungCapAI { get; set; }

        [StringLength(100)]
        public string TenKetQua { get; set; }
        [StringLength(100)]
        public string Hash { get; set; }
    }
}
