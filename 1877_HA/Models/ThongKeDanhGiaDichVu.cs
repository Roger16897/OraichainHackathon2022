using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1877_HA.Models
{
    public class ThongKeDanhGiaDichVu
    {
        public int ID { get; set; }
        public string TenDichVu { get; set; }
        public double SaoTrungBinh { get; set; }
        public int Sao5 { get; set; }
        public int Sao4 { get; set; }
        public int Sao3 { get; set; }
        public int Sao2 { get; set; }
        public int Sao1 { get; set; }
        public int TongDanhGia { get; set; }
        public string diswidth { get; set; }
    }
}