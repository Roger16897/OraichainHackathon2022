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
    [Route("api/ApiUser/{action}", Name = "ApiUserApi")]
    public class ApiUserController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var tb_user = _context.tb_User.Select(i => new {
                i.ID,
                i.TenDayDu,
                i.TenDangNhap,
                i.MatKhau,
                i.NgaySinh,
                i.GioiTinh,
                i.Email,
                i.isAdmin,
                i.Type,
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_user, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {
            var model = new tb_User();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_User.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_User.FirstOrDefaultAsync(item => item.ID == key);
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_User not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_User.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_User.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_User model, IDictionary values)
        {
            string ID = nameof(tb_User.ID);
            string TEN_DAY_DU = nameof(tb_User.TenDayDu);
            string TEN_DANG_NHAP = nameof(tb_User.TenDangNhap);
            string MAT_KHAU = nameof(tb_User.MatKhau);
            string NGAY_SINH = nameof(tb_User.NgaySinh);
            string GIOI_TINH = nameof(tb_User.GioiTinh);
            string EMAIL = nameof(tb_User.Email);
            string IS_ADMIN = nameof(tb_User.isAdmin);
            string TYPE= nameof(tb_User.Type);

            if (values.Contains(ID))
            {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(TEN_DAY_DU))
            {
                model.TenDayDu = Convert.ToString(values[TEN_DAY_DU]);
            }

            if (values.Contains(TEN_DANG_NHAP))
            {
                model.TenDangNhap = Convert.ToString(values[TEN_DANG_NHAP]);
            }

            if (values.Contains(MAT_KHAU))
            {
                Coding codeing = new Coding();
                string matkhau = Convert.ToString(values[MAT_KHAU]);
                model.MatKhau = codeing.Encrypt(matkhau + codeing.salt);
            }

            if (values.Contains(NGAY_SINH))
            {
                model.NgaySinh = values[NGAY_SINH] != null ? Convert.ToDateTime(values[NGAY_SINH]) : (DateTime?)null;
            }

            if (values.Contains(GIOI_TINH))
            {
                model.GioiTinh = Convert.ToString(values[GIOI_TINH]);
            }

            if (values.Contains(EMAIL))
            {
                model.Email = Convert.ToString(values[EMAIL]);
            }

            if (values.Contains(IS_ADMIN))
            {
                model.isAdmin = values[IS_ADMIN] != null ? Convert.ToBoolean(values[IS_ADMIN]) : (bool?)null;
            }
            if (values.Contains(TYPE))
            {
                model.Type = Convert.ToString(values[TYPE]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}