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
    //[AuthorizeApiController]
    [Route("api/ApiNhaCungCapAI/{action}", Name = "ApiNhaCungCapAIApi")]
    public class ApiNhaCungCapAIController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var tb_nhacungcapai = _context.tb_NhaCungCapAI.Select(i => new {
                i.ID,
                i.TenNhaCungCap,
                i.MoTa,
                i.ID_LoaiDichVu
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_nhacungcapai, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new tb_NhaCungCapAI();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_NhaCungCapAI.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_NhaCungCapAI.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_NhaCungCapAI not found");

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
            var model = await _context.tb_NhaCungCapAI.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_NhaCungCapAI.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_NhaCungCapAI model, IDictionary values) {
            string ID = nameof(tb_NhaCungCapAI.ID);
            string TEN_NHA_CUNG_CAP = nameof(tb_NhaCungCapAI.TenNhaCungCap);
            string MO_TA = nameof(tb_NhaCungCapAI.MoTa);
            string ID_LOAI_DICH_VU = nameof(tb_NhaCungCapAI.ID_LoaiDichVu);

            if(values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TEN_NHA_CUNG_CAP)) {
                model.TenNhaCungCap = Convert.ToString(values[TEN_NHA_CUNG_CAP]);
            }

            if(values.Contains(MO_TA)) {
                model.MoTa = Convert.ToString(values[MO_TA]);
            }

            if(values.Contains(ID_LOAI_DICH_VU)) {
                model.ID_LoaiDichVu = values[ID_LOAI_DICH_VU] != null ? Convert.ToInt32(values[ID_LOAI_DICH_VU]) : (int?)null;
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
        [HttpGet]
        public async Task<HttpResponseMessage> tb_LoaiDichVuLookup(DataSourceLoadOptions loadOptions)
        {
            var list = _context.tb_LoaiDichVu.Select(i => new {
                i.ID,
                i.TenLoaiDichVu
            });
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(list, loadOptions));
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}