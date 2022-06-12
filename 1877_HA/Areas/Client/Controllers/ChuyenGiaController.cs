using _1877_HA.Controllers;
using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Client.Controllers
{
    public class ChuyenGiaController : BaseController
    {
        // GET: Client/ChuyenGia
        ModelOrai db = new ModelOrai();
        public ActionResult Index()
        {
            var list = db.tb_ChuyenGia.ToList();
            return View(list);
        }
        public ActionResult GuiChuyenGia(int? id)
        {
            try
            {
                var chuyengia = db.tb_ChuyenGia.Find(id);
                ViewBag.TenChuyenGia = chuyengia.TenChuyenGia;
                ViewBag.Image = chuyengia.Image;
                ViewBag.TrinhDo = chuyengia.TrinhDo;
                ViewBag.MoTa = chuyengia.MoTa;
                ViewBag.IDChuyenGia = id;
                // lấy list kết quả
                if(Session["uid"].ToString()==null || Session["uid"].ToString()=="")
                {
                    return Redirect("/Login/Index");
                }
                int userID = Convert.ToInt32(Session["uid"].ToString());
                var listketqua = db.tb_KetQuaAI.Where(x => x.ID_User == userID).ToList();
                List<SelectListItem> danhsachketqua = new List<SelectListItem>();
                foreach(var item in listketqua)
                {
                    danhsachketqua.Add(new SelectListItem() { Text = item.TenKetQua, Value = item.ID.ToString() });
                }
                ViewBag.KetQua = danhsachketqua;

                //lay list binh luan
                var listdanhgiachuyengia = (from danhgiachuyengia in db.tb_RatingChuyenGia
                                           join khachhang in db.tb_User on danhgiachuyengia.ID_KhachHang equals khachhang.ID
                                           where danhgiachuyengia.ID_ChuyenGia == id
                                           select new
                                           {
                                               TenKhachHang = khachhang.TenDayDu,
                                               NoiDungBinhLuan = danhgiachuyengia.BinhLuan,
                                               Rate = danhgiachuyengia.Star
                                           }).ToList();
                ViewBag.listdanhgiachuyengia = listdanhgiachuyengia;


                return View();
            }
            catch
            {
                return Redirect("/Client/Error/Index");
            }
        }
        [HttpPost]
        public JsonResult GuiKetQua(HttpPostedFileBase file,int id_chuyengia,int id_ketquaAI)
        {
            try
            {
                tb_KetQuaAI ketQuaAI = db.tb_KetQuaAI.Find(id_ketquaAI);
                tb_CongViec congviec = new tb_CongViec();
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension == ".png" || extension == ".jpg" || extension == ".gif")
                    {
                        Coding codeing = new Coding();
                        string path_hash = codeing.Encrypt(ketQuaAI.ID_User.ToString());
                        string path_ketqua = Path.Combine(Server.MapPath("~/Assets/ImageKetQua"), path_hash);
                        if (!Directory.Exists(path_ketqua))
                        {
                            Directory.CreateDirectory(path_ketqua);
                        }
                        string path_file = Path.Combine(path_ketqua, Path.GetFileName(file.FileName));
                        file.SaveAs(path_file);
                        congviec.Image = path_hash + "/" + Path.GetFileName(file.FileName);

                    }
                }
                else
                {
                    congviec.Image = null;
                }
                congviec.ID_KetQuaAI = id_ketquaAI;
                congviec.ID_ChuyenGia = id_chuyengia;
                congviec.TrangThaiChuyenGia = "Chờ xử lý";
                congviec.TenKetQua = "Chuyên gia đánh giá :" + ketQuaAI.TenKetQua;
                db.tb_CongViec.Add(congviec);
                db.SaveChanges();
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "CongViec", new { Area = "Client" }),
                    status = true
                });


            }
            catch
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Home", new { Area = "Client" }),
                    status = false
                });
            }
        }


        [HttpPost]
        public JsonResult DanhGia(int idchuyengia, float rate, string noidungcmt)
        {
            try
            {
                //danh gia dich vu
                int userID = Convert.ToInt32(Session["uid"].ToString());
                tb_RatingChuyenGia ratingchuyengia = new tb_RatingChuyenGia();
                ratingchuyengia.BinhLuan = noidungcmt;
                ratingchuyengia.ID_ChuyenGia = idchuyengia;
                ratingchuyengia.Star = rate;
                ratingchuyengia.ID_KhachHang = userID;
                db.tb_RatingChuyenGia.Add(ratingchuyengia);
                db.SaveChanges();
                return Json(new
                {
                    mess = "Thao tác thành công!",
                    status = true
                });
            }
            catch
            {
                return Json(new
                {
                    mess = "Thao tác thất bại",
                    status = false
                });
            }
        }
    }
}