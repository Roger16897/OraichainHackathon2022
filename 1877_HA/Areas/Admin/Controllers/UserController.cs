using _1877_HA.Controllers;
using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class UserController : BaseController
    {
        ModelOrai db = new ModelOrai();
        // GET: User
        public ActionResult DanhSachNguoiDung()
        {
            return View();
        }

        public ActionResult GetController()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatQuyen()
        {
            ReflectionController rc = new ReflectionController();
          //  List<Type> listControllerType = rc.GetControllers("_1877_HA.Areas.Admin.Controllers");
            List<Type> listControllerType = rc.GetControllers("_1877_HA.Controllers");

            List<string> listControllerOld = db.tb_Controller.Select(c => c.ControllerName).ToList();
            List<string> listActionOld = db.tb_Action.Select(c => c.ActionName).ToList();
            foreach (var c in listControllerType)
            {
                if (!listControllerOld.Contains(c.Name))
                {
                    tb_Controller controller = new tb_Controller()
                    {
                        ControllerName = c.Name,
                        MoTa = "Chưa có mô tả"
                    };
                    db.tb_Controller.Add(controller);
                    db.SaveChanges();
                }
                List<string> listPermission = rc.GetActions(c);
                foreach (var p in listPermission)
                {
                    if (!listActionOld.Contains(c.Name + "-" + p))
                    {
                        tb_Action action = new tb_Action()
                        {
                            ActionName = c.Name + "-" + p,
                            MoTa = "Chưa có mô tả",
                            ID_Controller = db.tb_Controller.Where(x => x.ControllerName == c.Name).FirstOrDefault().ID
                        };
                        db.tb_Action.Add(action);
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("GetController");
        }

        public ActionResult UserAddRoleView(System.Int32 ID)
        {
            ViewBag.Controller = db.tb_Controller.ToList();
            ViewBag.Action = db.tb_Action.ToList();
            ViewBag.Permission = db.tb_PhanQuyen.Where(i => i.Id_NguoiDung == ID);
            Session["user_permission"] = ID.ToString();
            Session["username_permission"] = db.tb_User.Find(ID).TenDangNhap;
            return View();
        }

        public ActionResult UserAddRoleApply(string[] my_multi_select3)
        {
            var modelItemParam = db.tb_PhanQuyen;
            tb_PhanQuyen per = new tb_PhanQuyen();
            if (my_multi_select3 == null)
            {
                int userID = int.Parse(Session["user_permission"].ToString());
                var list = db.tb_PhanQuyen.Where(x => x.Id_NguoiDung == userID).ToList();
                foreach (var item in list)
                {
                    tb_PhanQuyen pq = db.tb_PhanQuyen.Find(item.ID);
                    db.tb_PhanQuyen.Remove(pq);
                }
                db.SaveChanges();
            }
            else
            {
                int userID = int.Parse(Session["user_permission"].ToString());
                var listper = db.tb_PhanQuyen.Where(x => x.Id_NguoiDung == userID).ToList();
                foreach (var item in listper)
                {
                    tb_PhanQuyen phanquyen = db.tb_PhanQuyen.Find(item.ID);
                    db.tb_PhanQuyen.Remove(phanquyen);
                }
                for (int i = 0; i < my_multi_select3.Length; i++)
                {
                    per.Id_NguoiDung = Convert.ToInt32(Session["user_permission"]);
                    per.Id_Action = Convert.ToInt32(my_multi_select3[i]);
                    modelItemParam.Add(per);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("DanhSachNguoiDung");
        }
        public ActionResult Info()
        {
            //int userID = int.Parse(Session["uid"].ToString());
            //var user = db.tb_User.Find(userID);
            //return View(user);
            try
            {

                if (Convert.ToInt32(Convert.ToInt32(Session["status_EditNguoiDung"])) != 0)
                {
                    ViewBag.Status = Convert.ToInt32(Session["status_EditNguoiDung"]);
                }
                Session["status_EditNguoiDung"] = 0;

                string id = Session["uid"].ToString();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                List<SelectListItem> gioitinh = new List<SelectListItem>();
                gioitinh.Add(new SelectListItem() { Text = "Nam", Value = "Nam" });
                gioitinh.Add(new SelectListItem() { Text = "Nữ", Value = "Nữ" });
                ViewBag.GioiTinh = gioitinh;
                int userID = int.Parse(id);
                var user = db.tb_User.Find(userID);
                ViewBag.GioiTinhValue = user.GioiTinh;
                ViewBag.NgaySinh = Convert.ToDateTime(user.NgaySinh).ToString("yyyy-MM-dd");
                return View(user);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NguoiDung nguoidungnew)
        {
            try
            {
                string id = Session["uid"].ToString();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (nguoidungnew.MatKhauCu == nguoidungnew.MatKhauMoi)
                {
                    //mat khau cu khac mat khau moi
                    Session["status_EditNguoiDung"] = -2;
                }
                else
                {
                    tb_User nguoidung = db.tb_User.Find(Convert.ToInt32(id));

                    Coding codeing = new Coding();
                    string matkhau_hash_old = codeing.Encrypt(nguoidungnew.MatKhauCu + codeing.salt);
                    if (nguoidung.MatKhau != matkhau_hash_old)
                    {
                        //mat khau cu khong dung
                        Session["status_EditNguoiDung"] = -3;
                    }
                    else
                    {
                        string matkhau_hash_new = codeing.Encrypt(nguoidungnew.MatKhauMoi + codeing.salt);
                        nguoidung.MatKhau = matkhau_hash_new;
                        nguoidung.TenDayDu = nguoidungnew.TenDayDu;
                        nguoidung.TenDangNhap = nguoidungnew.TenDangNhap;
                        nguoidung.NgaySinh = nguoidungnew.NgaySinh;
                        nguoidung.GioiTinh = nguoidungnew.GioiTinh;
                        nguoidung.Email = nguoidungnew.Email;
                        db.SaveChanges();
                        Session["status_EditNguoiDung"] = 1;
                    }
                }


                return RedirectToAction("Info");
            }
            catch
            {
                //co loi xay ra
                Session["status_EditNguoiDung"] = -1;
                return RedirectToAction("Info");
            }

        }
    }
}