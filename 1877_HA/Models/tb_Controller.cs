namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Controller
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ControllerName { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }
    }
}
