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
    [Route("api/ApiLoaiDichVu/{action}", Name = "ApiLoaiDichVuApi")]
    public class ApiLoaiDichVuController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var tb_loaidichvu = _context.tb_LoaiDichVu.Select(i => new {
                i.ID,
                i.TenLoaiDichVu,
                i.Gia,
                i.MoTa
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_loaidichvu, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new tb_LoaiDichVu();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_LoaiDichVu.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_LoaiDichVu.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_LoaiDichVu not found");

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
            var model = await _context.tb_LoaiDichVu.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_LoaiDichVu.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_LoaiDichVu model, IDictionary values) {
            string ID = nameof(tb_LoaiDichVu.ID);
            string TEN_LOAI_DICH_VU = nameof(tb_LoaiDichVu.TenLoaiDichVu);
            string GIA = nameof(tb_LoaiDichVu.Gia);
            string MO_TA = nameof(tb_LoaiDichVu.MoTa);

            if(values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TEN_LOAI_DICH_VU)) {
                model.TenLoaiDichVu = Convert.ToString(values[TEN_LOAI_DICH_VU]);
            }

            if(values.Contains(GIA)) {
                model.Gia = Convert.ToString(values[GIA]);
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