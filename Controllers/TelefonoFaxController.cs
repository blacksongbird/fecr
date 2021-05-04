using FECR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FECR.Controllers
{
    public class TelefonoFaxController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            TelefonoFax telefonofax = new TelefonoFax();
            telefonofax.CodigoPais1 = Convert.ToInt32(form.Get("CodPais"));
            telefonofax.NumTelefono1 = Convert.ToInt32(form.Get("NumTel"));

            string[] respuesta = new string[2];
            respuesta[0] = telefonofax.Update_TelefonoFax();
            respuesta[1] = form.Get("NumTel");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            TelefonoFax telefonofax = new TelefonoFax();
            telefonofax.CodigoPais1 = Convert.ToInt32(form.Get("CodPais"));
            telefonofax.NumTelefono1 = Convert.ToInt32(form.Get("NumTel"));

            string[] respuesta = new string[2];
            respuesta[0] = telefonofax.Insert_TelefonoFax();
            respuesta[1] = form.Get("NumTel");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            TelefonoFax telefonofax = new TelefonoFax();
            telefonofax.NumTelefono1 = Convert.ToInt32(form.Get("NumTel"));

            string[] respuesta = new string[2];
            respuesta[0] = telefonofax.Delete_TelefonoFax();
            respuesta[1] = form.Get("NumTel");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            TelefonoFax telefonofax = new TelefonoFax();

            HttpResponseMessage response = Request.CreateResponse<List<Models.TelefonoFax>>(HttpStatusCode.Created, telefonofax.Select_Todo_TelefonoFax());
            return response;
        }
    }
}
