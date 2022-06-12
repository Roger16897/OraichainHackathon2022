using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1877_HA.Models
{
    public class DichVu
    {
        public int ID { get; set; }
        public string TenDichVu { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
        public string TenLoaiDichVu { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}