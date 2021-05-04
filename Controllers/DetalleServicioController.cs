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
    public class DetalleServicioController : ApiController
    {

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            DetalleServicio detalleservicio = new DetalleServicio();

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            detalleservicio.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = detalleservicio.Insert_DetalleServicio();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            DetalleServicio detalleservicio = new DetalleServicio();

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            detalleservicio.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = detalleservicio.Delete_DetalleServicio();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            DetalleServicio detalleservicio = new DetalleServicio();

            HttpResponseMessage response = Request.CreateResponse<List<Models.DetalleServicio>>(HttpStatusCode.Created, detalleservicio.Select_Todo_DetalleServicio());
            return response;
        }
    }
}
