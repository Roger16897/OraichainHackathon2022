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
using Newtonsoft.Json.Linq;

namespace _1877_HA.Controllers
{
    [AuthorizeApiController]
    [Route("api/ApiAdminCongViec/{action}", Name = "ApiAdminCongViecApi")]
    public class ApiAdminCongViecController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var tb_congviec = from congviec in _context.tb_CongViec
                       join ketquaAI in _context.tb_KetQuaAI on congviec.ID_KetQuaAI equals ketquaAI.ID
                       join nguoidung in _context.tb_User on ketquaAI.ID_User equals nguoidung.ID
                       join dichvu in _context.tb_DichVu on ketquaAI.ID_DichVu equals dichvu.ID
                       select new
                       {
                           congviec.ID,
                           congviec.TenKetQua,
                           nguoidung.TenDayDu,
                           congviec.TrangThaiChuyenGia,
                           congviec.KetQuaChuyenGia,
                           ketquaAI.KetQuaNhaCungCapAI,
                           dichvu.TenDichVu,
                           congviec.Hash
                       };

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_congviec, loadOptions));
        }

      
        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_CongViec.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_CongViec not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);
            //sinh ma hash
            if (model.TrangThaiChuyenGia == "Hoàn thành")
            {
                //sinh ma hash
                string baseurl = "http://66.42.37.49:3000/addExpertResponse";
                Coding code = new Coding();
                SendRequestToAPI sendrequets = new SendRequestToAPI();
                string expert_id = code.Encrypt(model.ID_ChuyenGia.ToString() + code.salt);
                string input_data = code.Encrypt(DateTime.Now.ToString() + code.salt + model.ID_KetQuaAI);
                string expert_output_data = code.Encrypt(model.KetQuaChuyenGia);
                string res = await sendrequets.addExpertResponse(baseurl, expert_id, input_data, expert_output_data);
                var data = (JObject)JsonConvert.DeserializeObject(res);
                var hash = data["txHash"].ToString();
                model.Hash = hash;
            }
            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private void PopulateModel(tb_CongViec model, IDictionary values) {
            string ID = nameof(tb_CongViec.ID);
            string ID_KET_QUA_AI = nameof(tb_CongViec.ID_KetQuaAI);
            string ID_CHUYEN_GIA = nameof(tb_CongViec.ID_ChuyenGia);
            string KET_QUA_CHUYEN_GIA = nameof(tb_CongViec.KetQuaChuyenGia);
            string TRANG_THAI_CHUYEN_GIA = nameof(tb_CongViec.TrangThaiChuyenGia);
            string TEN_KET_QUA = nameof(tb_CongViec.TenKetQua);
            string IMAGE = nameof(tb_CongViec.Image);
            if (values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(ID_KET_QUA_AI)) {
                model.ID_KetQuaAI = values[ID_KET_QUA_AI] != null ? Convert.ToInt32(values[ID_KET_QUA_AI]) : (int?)null;
            }

            if(values.Contains(ID_CHUYEN_GIA)) {
                model.ID_ChuyenGia = values[ID_CHUYEN_GIA] != null ? Convert.ToInt32(values[ID_CHUYEN_GIA]) : (int?)null;
            }

            if(values.Contains(KET_QUA_CHUYEN_GIA)) {
                model.KetQuaChuyenGia = Convert.ToString(values[KET_QUA_CHUYEN_GIA]);
            }

            if(values.Contains(TRANG_THAI_CHUYEN_GIA)) {
                model.TrangThaiChuyenGia = Convert.ToString(values[TRANG_THAI_CHUYEN_GIA]);
            }

            if(values.Contains(TEN_KET_QUA)) {
                model.TenKetQua = Convert.ToString(values[TEN_KET_QUA]);
            }

            if(values.Contains(IMAGE)) {
                model.Image = Convert.ToString(values[IMAGE]);
            }

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