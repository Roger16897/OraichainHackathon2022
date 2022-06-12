namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_PhanQuyen
    {
        public int ID { get; set; }

        public int? Id_Action { get; set; }

        public int? Id_NguoiDung { get; set; }
    }
}
