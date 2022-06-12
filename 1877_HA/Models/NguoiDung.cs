using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1877_HA.Models
{
    public class NguoiDung
    {
        public int ID { get; set; }

        public string TenDayDu { get; set; }

        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }
        public string MatKhauCu { get; set; }
        public string MatKhauMoi { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        public string Email { get; set; }
    }
}