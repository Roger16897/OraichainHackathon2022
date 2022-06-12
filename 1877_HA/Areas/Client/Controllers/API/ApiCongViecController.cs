using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using _1877_HA.Models;
using System.Web;

namespace _1877_HA.Controllers
{
    [Route("api/ApiCongViec/{action}", Name = "ApiCongViecApi")]
    public class ApiCongViecController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            int maND = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());
            var tb_congviec = from congviec in _context.tb_CongViec
                       join ketquaAI in _context.tb_KetQuaAI on congviec.ID_KetQuaAI equals ketquaAI.ID
                       join dichvu in _context.tb_DichVu on ketquaAI.ID_DichVu equals dichvu.ID
                       join chuyengia in _context.tb_ChuyenGia on congviec.ID_ChuyenGia equals chuyengia.ID
                       join loaidichvu in _context.tb_LoaiDichVu on dichvu.ID_LoaiDichVu equals loaidichvu.ID
                       where ketquaAI.ID_User == maND
                       select new
                       {
                           congviec.ID,
                           congviec.TenKetQua,
                           chuyengia.TenChuyenGia,
                           dichvu.TenDichVu,
                           loaidichvu.TenLoaiDichVu,
                           congviec.KetQuaChuyenGia,
                           congviec.TrangThaiChuyenGia,
                           congviec.Hash
                       };

            //var tb_congviec = _context.tb_CongViec.Select(i => new {
            //    i.ID,
            //    i.ID_KetQuaAI,
            //    i.ID_ChuyenGia,
            //    i.KetQuaChuyenGia,
            //    i.TrangThaiChuyenGia,
            //    i.TenKetQua,
            //    i.Image
            //});
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_congviec, loadOptions));
        }

     
        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}