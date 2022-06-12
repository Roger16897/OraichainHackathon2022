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
    [AuthorizeApiController]

    [Route("api/ApiDichVu/{action}", Name = "ApiDichVuApi")]
    public class ApiDichVuController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            //var tb_dichvu = _context.tb_DichVu.Select(i => new {
            //    i.ID,
            //    i.TenDichVu,
            //    i.MoTa,
            //    i.Gia,
            //    i.ID_LoaiDichVu,
            //    i.ID_NhaCungCapAI,
            //    i.ID_User
            //});
            int maND= Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());
            var tb_dichvu = from i in _context.tb_DichVu
                            where i.ID_User ==maND
                            select new
                            {
                                i.ID,
                                i.TenDichVu,
                                i.MoTa,
                                i.Gia,
                                i.ID_LoaiDichVu,
                                i.ID_NhaCungCapAI,
                                i.ID_User
                            };
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_dichvu, loadOptions));
            //return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_dichvu, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new tb_DichVu();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);
            model.ID_User = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());
            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_DichVu.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_DichVu.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_DichVu not found");
            model.ID_User = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task Delete(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_DichVu.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_DichVu.Remove(model);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> tb_LoaiDichVuLookup(DataSourceLoadOptions loadOptions)
        {
            var list = _context.tb_LoaiDichVu.Select(i => new {
                i.ID,
                i.TenLoaiDichVu
            });
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(list, loadOptions));
        }
        [HttpGet]
        public async Task<HttpResponseMessage> tb_NhaCungCapLookup(DataSourceLoadOptions loadOptions)
        {
            var list = _context.tb_NhaCungCapAI.Select(i => new {
                i.ID,
                i.TenNhaCungCap
            });
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(list, loadOptions));
        }
        private void PopulateModel(tb_DichVu model, IDictionary values) {
            string ID = nameof(tb_DichVu.ID);
            string TEN_DICH_VU = nameof(tb_DichVu.TenDichVu);
            string MO_TA = nameof(tb_DichVu.MoTa);
            string GIA = nameof(tb_DichVu.Gia);
            string ID_LOAI_DICH_VU = nameof(tb_DichVu.ID_LoaiDichVu);
            string ID_NHA_CUNG_CAP_AI = nameof(tb_DichVu.ID_NhaCungCapAI);
            string ID_USER = nameof(tb_DichVu.ID_User);

            if(values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TEN_DICH_VU)) {
                model.TenDichVu = Convert.ToString(values[TEN_DICH_VU]);
            }

            if(values.Contains(MO_TA)) {
                model.MoTa = Convert.ToString(values[MO_TA]);
            }

            if(values.Contains(GIA)) {
                model.Gia = Convert.ToString(values[GIA]);
            }

            if(values.Contains(ID_LOAI_DICH_VU)) {
                model.ID_LoaiDichVu = values[ID_LOAI_DICH_VU] != null ? Convert.ToInt32(values[ID_LOAI_DICH_VU]) : (int?)null;
            }

            if(values.Contains(ID_NHA_CUNG_CAP_AI)) {
                model.ID_NhaCungCapAI = values[ID_NHA_CUNG_CAP_AI] != null ? Convert.ToInt32(values[ID_NHA_CUNG_CAP_AI]) : (int?)null;
            }

            if(values.Contains(ID_USER)) {
                model.ID_User = values[ID_USER] != null ? Convert.ToInt32(values[ID_USER]) : (int?)null;
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