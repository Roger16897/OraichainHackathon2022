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
    [Route("api/ApiCauHinhThamSo/{action}", Name = "ApiCauHinhThamSoApi")]
    public class ApiCauHinhThamSoController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            //var tb_cauhinhthamso = _context.tb_CauHinhThamSo.Select(i => new {
            //    i.ID,
            //    i.TenTruong,
            //    i.ID_DichVu,
            //    i.MoTa
            //});
            int maND = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());
            var tb_cauhinhthamso = from i in _context.tb_CauHinhThamSo
                                   join dichvu in _context.tb_DichVu on i.ID_DichVu equals dichvu.ID
                                   where dichvu.ID_User == maND
                                   select new
                                   {
                                       i.ID,
                                       i.TenTruong,
                                       i.ID_DichVu,
                                       i.MoTa
                                   };
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_cauhinhthamso, loadOptions));
        }
        [HttpGet]
        public async Task<HttpResponseMessage> tb_DichVuLookup(DataSourceLoadOptions loadOptions)
        {
            int maND = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());

            var lookup = from i in _context.tb_DichVu
                         where i.ID_User == maND
                         select new
                         {
                             Value = i.ID,
                             Text = i.TenDichVu
                         };
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(lookup, loadOptions));
            //var list = _context.tb_DichVu.Select(i => new {
            //    i.ID,
            //    i.TenDichVu
            //});
            //return Request.CreateResponse(await DataSourceLoader.LoadAsync(list, loadOptions));
        }
        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new tb_CauHinhThamSo();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_CauHinhThamSo.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_CauHinhThamSo.FirstOrDefaultAsync(item => item.ID == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_CauHinhThamSo not found");

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
            var model = await _context.tb_CauHinhThamSo.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_CauHinhThamSo.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_CauHinhThamSo model, IDictionary values) {
            string ID = nameof(tb_CauHinhThamSo.ID);
            string TEN_TRUONG = nameof(tb_CauHinhThamSo.TenTruong);
            string ID_DICH_VU = nameof(tb_CauHinhThamSo.ID_DichVu);
            string MO_TA = nameof(tb_CauHinhThamSo.MoTa);

            if(values.Contains(ID)) {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(TEN_TRUONG)) {
                model.TenTruong = Convert.ToString(values[TEN_TRUONG]);
            }

            if(values.Contains(ID_DICH_VU)) {
                model.ID_DichVu = values[ID_DICH_VU] != null ? Convert.ToInt32(values[ID_DICH_VU]) : (int?)null;
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