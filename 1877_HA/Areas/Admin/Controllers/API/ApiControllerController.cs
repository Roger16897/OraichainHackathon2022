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
    [Route("api/ApiController/{action}", Name = "ApiControllerApi")]
    public class ApiControllerController : ApiController
    {
        private ModelOrai _context = new ModelOrai();

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var tb_controller = _context.tb_Controller.Select(i => new {
                i.ID,
                i.ControllerName,
                i.MoTa
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(tb_controller, loadOptions));
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetActionByController(DataSourceLoadOptions loadOptions, int id)
        {

            var action = from i in _context.tb_Action
                         where i.ID_Controller == id
                         select new
                         {
                             i.ID,
                             i.ActionName,
                             i.MoTa
                         };
            return Request.CreateResponse(await DataSourceLoader.LoadAsync(action, loadOptions));
        }
        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {
            var model = new tb_Controller();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.tb_Controller.Add(model);
            await _context.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, result.ID);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var model = await _context.tb_Controller.FirstOrDefaultAsync(item => item.ID == key);
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "tb_Controller not found");

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
            var model = await _context.tb_Controller.FirstOrDefaultAsync(item => item.ID == key);

            _context.tb_Controller.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(tb_Controller model, IDictionary values)
        {
            string ID = nameof(tb_Controller.ID);
            string CONTROLLER_NAME = nameof(tb_Controller.ControllerName);
            string MO_TA = nameof(tb_Controller.MoTa);

            if (values.Contains(ID))
            {
                model.ID = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(CONTROLLER_NAME))
            {
                model.ControllerName = Convert.ToString(values[CONTROLLER_NAME]);
            }

            if (values.Contains(MO_TA))
            {
                model.MoTa = Convert.ToString(values[MO_TA]);
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