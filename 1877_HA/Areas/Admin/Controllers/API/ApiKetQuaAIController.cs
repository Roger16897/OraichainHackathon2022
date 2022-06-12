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
    //[AuthorizeApiController]
    [Route("api/ApiKetQuaAI/{action}", Name = "ApiKetQuaAIApi")]
    public class ApiKetQuaAIController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            int maND = Convert.ToInt16(HttpContext.Current.Session["uid"].ToString());

            //var tb_ketquaai = _context.tb_KetQuaAI.Select(i => new {
            //    i.ID,
            //    i.ID_DichVu,
            //    i.ID_User,
            //    i.KetQuaNhaCungCapAI,
            //    i.TenKetQua,
            //    i.Hash
            //});
            var tb_ketquaai = from i in _context.tb_KetQuaAI
                              join dichvu in _context.tb_DichVu on i.ID_DichVu equals dichvu.ID
                              join user in _context.tb_User on i.ID_User equals user.ID
                              where dichvu.ID_User==maND
                              select new
                              {
                                  ID=i.ID,
                                  TenDichVu=dichvu.TenDichVu,
                                  TenNguoiDung=user.TenDayDu,
                                  KetQuaNhaCungCapAI=i.KetQuaNhaCungCapAI,
                                  TenKetQua=i.TenKetQua,
                                  Hash=i.Hash
                              };

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_ketquaai, loadOptions));
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