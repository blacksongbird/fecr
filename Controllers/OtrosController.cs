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
    public class OtrosController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Otros otros = new Otros();
            otros.OtroTexto1 = form.Get("OtroTexto");
            otros.OtroContenido1 = form.Get("OtroContenido");
            
            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            otros.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otros.Update_Otros();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Otros otros = new Otros();

            otros.OtroTexto1 = form.Get("OtroTexto");
            otros.OtroContenido1 = form.Get("OtroContenido");

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            otros.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otros.Insert_Otros();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Otros otros = new Otros();
            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            otros.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otros.Delete_Otros();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            Otros otros = new Otros();
            Factura clave = new Factura();
            clave.Clave1 = id;
            otros.Clave1 = clave;

            HttpResponseMessage response = Request.CreateResponse<Models.Otros>(HttpStatusCode.Created, otros.Select_Otros());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Otros otros = new Otros();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Otros>>(HttpStatusCode.Created, otros.Select_Todo_Otros());
            return response;
        }
    }
}
