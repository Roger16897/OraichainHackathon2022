using _1877_HA.Controllers;
using _1877_HA.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _1877_HA.Areas.Client.Controllers
{
    public class DichVuController : BaseController
    {
        // GET: Client/DichVu
        ModelOrai db = new ModelOrai();
        public List<DichVu> GetDichVu()
        {
            var query = (from dv in db.tb_DichVu
                              join nhaccai in db.tb_NhaCungCapAI on dv.ID_NhaCungCapAI equals nhaccai.ID
                              join loaidv in db.tb_LoaiDichVu on dv.ID_LoaiDichVu equals loaidv.ID
                              select new
                              {
                                  ID = dv.ID,
                                  TenDichVu = dv.TenDichVu,
                                  Gia = dv.Gia,
                                  MoTa = dv.MoTa,
                                  TenLoaiDichVu = loaidv.TenLoaiDichVu,
                                  TenNhaCungCap = nhaccai.TenNhaCungCap
                              }).ToList();
            var listdichvu = query.ToList().Select(r => new DichVu
            {
                ID = r.ID,
                TenDichVu = r.TenDichVu,
                Gia = r.Gia,
                MoTa = r.MoTa,
                TenLoaiDichVu = r.TenLoaiDichVu,
                TenNhaCungCap = r.TenNhaCungCap
            }).ToList();
            return listdichvu;
        }
        public ActionResult Index()
        {
            var listdichvu = GetDichVu();
            //ViewBag.ListDichVu = listdichvu;
            return View(listdichvu);
        }
        public ActionResult ChiTietDichVu(int? id)
        {
            try
            {
                ViewBag.ID = id;
                var listdichvu = GetDichVu();
                var dichvu = listdichvu.Where(x => x.ID == id).FirstOrDefault();
                ViewBag.IDDichVu = id;
                if(dichvu==null)
                {
                    return Redirect("/Client/Error/Index");
                }

                //lay list binh luan
                var listdanhgiadichvuAI = (from danhgiadichvu in db.tb_RatingNhaCungCap
                                           join khachhang in db.tb_User on danhgiadichvu.ID_KhachHang equals khachhang.ID
                                           where danhgiadichvu.ID_NhaCungCapAI == id
                                           select new
                                           {
                                               TenKhachHang = khachhang.TenDayDu,
                                               NoiDungBinhLuan = danhgiadichvu.BinhLuan,
                                               Rate = danhgiadichvu.Star
                                           }).ToList();
                ViewBag.listdanhgiadichvuAI = listdanhgiadichvuAI;

                return View();
            }
            catch
            {
                return Redirect("/Client/Error/Index");
            }
           
        }
        //public static async Task<string> sendPost(string urlAPI, string filename, byte[] fileContents)
        //{
        //    //byte[] fileContents = File.ReadAllBytes(filePath);
        //    HttpClient httpClient = new HttpClient();
        //    MultipartFormDataContent form = new MultipartFormDataContent();
        //    ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
        //    form.Add(byteArrayContent, "image", filename);
        //    HttpResponseMessage response = await httpClient.PostAsync(urlAPI, form);
        //    response.EnsureSuccessStatusCode();
        //    httpClient.Dispose();
        //    string result = response.Content.ReadAsStringAsync().Result;
        //    return result;

        //}

        public static async Task<string> sendPost(string urlAPI, string filename, byte[] fileContents)
        {
            //byte[] fileContents = File.ReadAllBytes(filePath);
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();
            ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
            form.Add(byteArrayContent, "image", filename);
            HttpResponseMessage response = await httpClient.PostAsync(urlAPI, form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        public static async Task<string> sendPostMalware(string urlAPI, string filename, byte[] fileContents)
        {
            //byte[] fileContents = File.ReadAllBytes(filePath);
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();
            ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
            form.Add(byteArrayContent, "data", filename);
            HttpResponseMessage response = await httpClient.PostAsync(urlAPI, form);
            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string result = response.Content.ReadAsStringAsync().Result;
            return result;

        }
        //[HttpPost]
        //public async Task<JsonResult> PhanTich()
        //{
        //    string filename = "";string datares = "";
        //    if (HttpContext.Request.Files.Count > 0)
        //    {
        //        HttpPostedFileBase imgFile = HttpContext.Request.Files[0];
        //        byte[] image = new byte[imgFile.ContentLength];
        //        imgFile.InputStream.Read(image, 0, image.Length);
        //        string result = await sendPost("http://127.0.0.1:5000/process",imgFile.FileName, image);
        //        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //        datares = result;
        //        //filename = (data["file_name"]).ToString();
        //        filename = imgFile.FileName;
        //        string ss1 = (data["syms"]).ToString();

        //    }
        //    return Json(new
        //    {
        //        filename = filename,
        //        data = datares,
        //        status = true
        //    });
        //    //return Json(true);
        //}
        [HttpPost]
        public async Task<JsonResult> PhanTich()
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                HttpPostedFileBase imgFile = HttpContext.Request.Files[0];
                byte[] image = new byte[imgFile.ContentLength];
                imgFile.InputStream.Read(image, 0, image.Length);
                string filename = await sendPost("http://45.76.158.89:5000/upload_file", imgFile.FileName, image);
                // xu ly anh (vẽ ảnh)
                SendRequestToAPI sendrequets = new SendRequestToAPI();
                string datares = await sendrequets.PostProcessDrawImage("http://66.42.37.49:1877/aioracle", "ThoracicDiseasesDetectionAndSegmentation", filename);
                return Json(new
                {
                    filename= filename,
                    data = datares,
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        //[HttpPost]
        //public async Task<JsonResult> PhanTichCovid()
        //{
        //    string datares = "";
        //    if (HttpContext.Request.Files.Count > 0)
        //    {
        //        HttpPostedFileBase imgFile = HttpContext.Request.Files[0];
        //        byte[] image = new byte[imgFile.ContentLength];
        //        imgFile.InputStream.Read(image, 0, image.Length);
        //        string result = await sendPost("http://127.0.0.1:5010/process", imgFile.FileName, image);
        //        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //        datares = result;

        //    }
        //    return Json(new
        //    {
        //        data = datares,
        //        status = true
        //    });
        //    //return Json(true);
        //}
        [HttpPost]
        public async Task<JsonResult> PhanTichCovid()
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                HttpPostedFileBase imgFile = HttpContext.Request.Files[0];
                byte[] image = new byte[imgFile.ContentLength];
                imgFile.InputStream.Read(image, 0, image.Length);
                string filename = await sendPost("http://45.76.158.89:5010/upload_file", imgFile.FileName, image);
                //xu ly du doan
                SendRequestToAPI sendrequets = new SendRequestToAPI();
                string datares = await sendrequets.PostProcessDrawImage("http://66.42.37.49:1877/aioracle", "AirSpaceSeverityGrading", filename);
                return Json(new
                {
                    filename = filename,
                    data = datares,
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
           
        }

        //[HttpPost]
        //public async Task<JsonResult> PhanTichMaDoc()
        //{
        //    string datares = "";
        //    if (HttpContext.Request.Files.Count > 0)
        //    {
        //        HttpPostedFileBase malFile = HttpContext.Request.Files[0];
        //        byte[] mal = new byte[malFile.ContentLength];
        //        malFile.InputStream.Read(mal, 0, mal.Length);
        //        string result = await sendPostMalware("http://127.0.0.1:5005/process", malFile.FileName, mal);
        //        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //        datares = result;

        //    }
        //    return Json(new
        //    {
        //        data = datares,
        //        status = true
        //    });
        //    //return Json(true);
        //}
        [HttpPost]
        public async Task<JsonResult> PhanTichMaDoc()
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                HttpPostedFileBase malFile = HttpContext.Request.Files[0];
                byte[] mal = new byte[malFile.ContentLength];
                malFile.InputStream.Read(mal, 0, mal.Length);
                string filename = await sendPostMalware("http://45.76.158.89:5005/upload_file", malFile.FileName, mal);
                //xu ly du doan
                SendRequestToAPI sendrequets = new SendRequestToAPI();
                string datares = await sendrequets.PostProcessDrawImage("http://66.42.37.49:1877/aioracle", "MalwareDetection", filename);
                return Json(new
                {
                    filename = filename,
                    data = datares,
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        [HttpPost]
        public async Task<JsonResult> LuuKetQua(int iddv, string ketquaAI,string tenketqua,string haship)
        {
            try
            {
                //call API blockchain
                string baseurl = "http://66.42.37.49:3000/addCustomerRequest";
                Coding code = new Coding();
                SendRequestToAPI sendrequets = new SendRequestToAPI();
                string user_id = "orai155u5y8dk5xjud930eqqksagsjt0f80s948rcrh";
                string input_data = code.Encrypt(DateTime.Now.ToString() + code.salt+tenketqua);
                string ai_service_id = haship;
                string ai_output_data = code.Encrypt(ketquaAI);
                string res = await sendrequets.addCustomerRequest(baseurl,user_id,input_data,ai_service_id, ai_output_data);

                var data = (JObject)JsonConvert.DeserializeObject(res);
                var hash = data["txHash"].ToString();
                // Luu ket qua vao database
                tb_KetQuaAI ketqua = new tb_KetQuaAI();
                ketqua.ID_DichVu = iddv;
                int userID = Convert.ToInt32(Session["uid"].ToString());
                ketqua.ID_User = userID;
                ketqua.KetQuaNhaCungCapAI = ketquaAI;
                ketqua.TenKetQua = tenketqua;
                ketqua.Hash = hash;
                db.tb_KetQuaAI.Add(ketqua);
                db.SaveChanges();
                return Json(new
                {
                    hashop = "https://testnet.scan.orai.io/txs/"+hash,
                    mess="Thao tác thành công!",
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

        [HttpPost]
        public JsonResult DanhGia(int iddv, float rate, string noidungcmt)
        {
            try
            {
                //danh gia dich vu
                int userID = Convert.ToInt32(Session["uid"].ToString());
                tb_RatingNhaCungCap ratingnhacungcap = new tb_RatingNhaCungCap();
                ratingnhacungcap.BinhLuan = noidungcmt;
                ratingnhacungcap.ID_NhaCungCapAI = iddv;
                ratingnhacungcap.Star = rate;
                ratingnhacungcap.ID_KhachHang = userID;
                db.tb_RatingNhaCungCap.Add(ratingnhacungcap);
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