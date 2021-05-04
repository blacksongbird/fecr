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
    public class CodigoComercialController : ApiController
    {

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            CodigoComercial codigocomercial = new CodigoComercial();
            codigocomercial.Tipo1 = form.Get("Tipo");
            codigocomercial.Codigo1 = form.Get("Codigo");

            string[] respuesta = new string[3];
            respuesta[0] = codigocomercial.Insert_CodigoComercial();
            respuesta[1] = form.Get("Tipo");
            respuesta[2] = form.Get("Codigo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            CodigoComercial codigocomercial = new CodigoComercial();
            codigocomercial.Tipo1 = form.Get("Tipo");
            codigocomercial.Codigo1 = form.Get("Codigo");

            string[] respuesta = new string[3];
            respuesta[0] = codigocomercial.Delete_CodigoComercial();
            respuesta[1] = form.Get("Tipo");
            respuesta[2] = form.Get("Codigo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            CodigoComercial codigocomercial = new CodigoComercial();

            HttpResponseMessage response = Request.CreateResponse<List<Models.CodigoComercial>>(HttpStatusCode.Created, codigocomercial.Select_Todo_CodigoComercial());
            return response;
        }
    }
}
