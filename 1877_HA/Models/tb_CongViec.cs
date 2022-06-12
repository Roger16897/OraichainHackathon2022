namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CongViec
    {
        public int ID { get; set; }

        public int? ID_KetQuaAI { get; set; }

        public int? ID_ChuyenGia { get; set; }

        public string KetQuaChuyenGia { get; set; }

        [StringLength(100)]
        public string TrangThaiChuyenGia { get; set; }

        [StringLength(100)]
        public string TenKetQua { get; set; }

        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(100)]
        public string Hash { get; set; }
    }
}
