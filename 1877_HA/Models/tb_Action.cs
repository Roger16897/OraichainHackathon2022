namespace _1877_HA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Action
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        public int? ID_Controller { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }
    }
}
