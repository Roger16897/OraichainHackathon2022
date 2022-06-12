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

namespace _1877_HA.Controllers
{
    [AuthorizeApiController]
    [Route("api/ApiChuyenGia/{action}", Name = "ApiChuyenGiaApi")]
    public class ApiChuyenGiaController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var tb_chuyengia = _context.tb_ChuyenGia.Select(i => new {
                i.ID,
                i.TenChuyenGia,
                i.NgaySinh,
                i.email,
                i.SDT,
                i.TrinhDo,
                i.MoTa,
                i.Image
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_chuyengia, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new tb_ChuyenGia();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_ChuyenGia.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_ChuyenGia.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_ChuyenGia not found");

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
            var model = await _context.tb_ChuyenGia.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_ChuyenGia.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_ChuyenGia model, IDictionary values) {
            string ID = nameof(tb_ChuyenGia.ID);
            string TEN_CHUYEN_GIA = nameof(tb_ChuyenGia.TenChuyenGia);
            string NGAY_SINH = nameof(tb_ChuyenGia.NgaySinh);
            string EMAIL = nameof(tb_ChuyenGia.email);
            string SDT = nameof(tb_ChuyenGia.SDT);
            string TRINH_DO = nameof(tb_ChuyenGia.TrinhDo);
            string MO_TA = nameof(tb_ChuyenGia.MoTa);

            if(values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TEN_CHUYEN_GIA)) {
                model.TenChuyenGia = Convert.ToString(values[TEN_CHUYEN_GIA]);
            }

            if(values.Contains(NGAY_SINH)) {
                model.NgaySinh = values[NGAY_SINH] != null ? Convert.ToDateTime(values[NGAY_SINH]) : (DateTime?)null;
            }

            if(values.Contains(EMAIL)) {
                model.email = Convert.ToString(values[EMAIL]);
            }

            if(values.Contains(SDT)) {
                model.SDT = Convert.ToString(values[SDT]);
            }

            if(values.Contains(TRINH_DO)) {
                model.TrinhDo = Convert.ToString(values[TRINH_DO]);
            }

            if(values.Contains(MO_TA)) {
                model.MoTa = Convert.ToString(values[MO_TA]);
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