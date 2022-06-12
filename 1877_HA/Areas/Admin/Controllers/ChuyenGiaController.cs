using _1877_HA.Controllers;
using _1877_HA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Admin.Controllers
{
    [AuthorizeController]
    public class ChuyenGiaController : BaseController
    {
        // GET: Admin/ChuyenGia
        ModelOrai db = new ModelOrai();
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Convert.ToInt32(Session["status_uploadCG"])) != 0)
                {
                    ViewBag.Status = Convert.ToInt32(Session["status_uploadCG"]);
                }
                Session["status_uploadCG"] = 0;
                return View();
            }
            catch
            {
                return Redirect("/Login/Index");
            }
            // return View();

        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file,tb_ChuyenGia chuyengia)
        {
            try
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension == ".png" || extension == ".jpg" || extension == ".gif")
                    {
                        Coding codeing = new Coding();
                        string path_hash = codeing.Encrypt(chuyengia.TenChuyenGia + chuyengia.NgaySinh + DateTime.Now.ToString());
                        string path_chuyengia = Path.Combine(Server.MapPath("~/Assets/ImageChuyenGia"), path_hash);
                        if (!Directory.Exists(path_chuyengia))
                        {
                            Directory.CreateDirectory(path_chuyengia);
                        }
                        string path_file = Path.Combine(path_chuyengia, Path.GetFileName(file.FileName));
                        file.SaveAs(path_file);

                       
                        chuyengia.Image = path_hash + "/" + Path.GetFileName(file.FileName);
                        chuyengia.NgaySinh = Convert.ToDateTime(chuyengia.NgaySinh);
                        db.tb_ChuyenGia.Add(chuyengia);
                        db.SaveChanges();
                        Session["status_uploadCG"] = 1;

                    }
                    else
                    {
                        Session["status_uploadCG"] = -2;

                    }
                }
                else
                {
                    Session["status_uploadCG"] = -3;
                }

                return RedirectToAction("/Index");

            }
            catch
            {
                Session["status_uploadCG"] = -1;
                return RedirectToAction("/Index");

            }
        }


        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,tb_ChuyenGia chuyengia)
        {
            try
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension == ".png" || extension == ".jpg" || extension == ".gif")
                    {
                        tb_ChuyenGia tb_chuyengia = db.tb_ChuyenGia.Find(chuyengia.ID);
                        if(tb_chuyengia.Image==null || tb_chuyengia.Image=="")
                        {
                            Coding codeing = new Coding();
                            string path_hash = codeing.Encrypt(chuyengia.TenChuyenGia + chuyengia.NgaySinh + DateTime.Now.ToString());
                            string path_chuyengia = Path.Combine(Server.MapPath("~/Assets/ImageChuyenGia"), path_hash);
                            if (!Directory.Exists(path_chuyengia))
                            {
                                Directory.CreateDirectory(path_chuyengia);
                            }
                            string path_file = Path.Combine(path_chuyengia, Path.GetFileName(file.FileName));
                            file.SaveAs(path_file);
                            tb_chuyengia.Image = path_hash + "/" + Path.GetFileName(file.FileName);

                        }
                        else
                        {
                            string pathhash = Path.GetDirectoryName(tb_chuyengia.Image);
                            string path_chuyengia = Path.Combine(Server.MapPath("~/Assets/ImageChuyenGia"), pathhash);
                            //xoa het anh cu
                            System.IO.DirectoryInfo di = new DirectoryInfo(path_chuyengia);
                            foreach (FileInfo file1 in di.GetFiles())
                            {
                                file1.Delete();
                            }
                            //luu anh moi
                            string path_file = Path.Combine(path_chuyengia, Path.GetFileName(file.FileName));
                            file.SaveAs(path_file);
                            tb_chuyengia.Image = pathhash+"/"+ Path.GetFileName(file.FileName);


                        }

                        tb_chuyengia.TenChuyenGia = chuyengia.TenChuyenGia;
                        tb_chuyengia.NgaySinh = Convert.ToDateTime(chuyengia.NgaySinh);
                        tb_chuyengia.email = chuyengia.email;
                        tb_chuyengia.SDT = chuyengia.SDT;
                        tb_chuyengia.TrinhDo = chuyengia.TrinhDo;
                        tb_chuyengia.MoTa = chuyengia.MoTa;
                        db.SaveChanges();
                        Session["status_uploadCG"] = 1;

                    }
                    else
                    {
                        Session["status_uploadCG"] = -2;

                    }
                }
                else
                {
                    Session["status_uploadCG"] = -3;
                }

                return RedirectToAction("/Index");

            }
            catch
            {
                Session["status_uploadCG"] = -1;
                return RedirectToAction("/Index");

            }
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                tb_ChuyenGia chuyengia = db.tb_ChuyenGia.Find(id);
                string pathhash = Path.GetDirectoryName(chuyengia.Image); 
                string folderPath = Path.Combine(Server.MapPath("~/Assets/ImageChuyenGia"), pathhash);
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }
                db.tb_ChuyenGia.Remove(chuyengia);
                db.SaveChanges();
                string msg = "Thao tác thành công !";
                return Json(new
                {
                    mess = msg,
                    success = true
                });
            }
            catch
            {
                string msg = "Thao tác thất bại !";
                return Json(new
                {
                    mess = msg,
                    success = false
                });
            }
        }
    }
}