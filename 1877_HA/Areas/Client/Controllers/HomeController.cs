using _1877_HA.Controllers;
using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Client.Controllers
{
    public class HomeController : BaseController
    {
        ModelOrai db = new ModelOrai();
        // GET: Client/Home
        public ActionResult Index()
        {
            List<ThongKeDanhGiaDichVu> Listdanhgiadichvu = new List<ThongKeDanhGiaDichVu>();
            var listdichvu = db.tb_DichVu.ToList();
            foreach(var dichvu in listdichvu)
            {
                ThongKeDanhGiaDichVu danhgiadichvu = new ThongKeDanhGiaDichVu();
                int sao5 = 0;int sao4 = 0;int sao3 = 0;int sao2 = 0;int sao1 = 0;
                var list_rate_nhaccai = db.tb_RatingNhaCungCap.Where(x => x.ID_NhaCungCapAI == dichvu.ID).ToList();
                if(list_rate_nhaccai.Count==0)
                {
                    danhgiadichvu.SaoTrungBinh = 0;
                    danhgiadichvu.diswidth = "0";
                }
                else
                {
                    foreach (var ratenhaccai in list_rate_nhaccai)
                    {
                        if (ratenhaccai.Star == 5)
                        {
                            sao5++;
                        }
                        else if (ratenhaccai.Star == 4)
                        {
                            sao4++;
                        }
                        else if (ratenhaccai.Star == 3)
                        {
                            sao3++;
                        }
                        else if (ratenhaccai.Star == 2)
                        {
                            sao2++;
                        }
                        else if (ratenhaccai.Star == 1)
                        {
                            sao1++;
                        }
                    }
                    var saotb = Convert.ToDouble((double)(5 * sao5 + 4 * sao4 + 3 * sao3 + 2 * sao2 + 1 * sao1) / (double)(list_rate_nhaccai.Count()));
                    danhgiadichvu.SaoTrungBinh = Math.Round(saotb,2);
                    double width = saotb * 20;
                    danhgiadichvu.diswidth= width.ToString();

                }
                danhgiadichvu.ID = dichvu.ID;
                danhgiadichvu.Sao1 = sao1;
                danhgiadichvu.Sao2 = sao2;
                danhgiadichvu.Sao3 = sao3;
                danhgiadichvu.Sao4 = sao4;
                danhgiadichvu.Sao5 = sao5;
                danhgiadichvu.TongDanhGia = list_rate_nhaccai.Count();
                danhgiadichvu.TenDichVu = dichvu.TenDichVu;
                Listdanhgiadichvu.Add(danhgiadichvu);
            }

            return View(Listdanhgiadichvu);
        }
    }
}